using System;
using System.Security.Cryptography;

namespace Warehouse.Service.Clients
{
	/// <summary>
	/// Password secure hasher.
	/// </summary>
	/// <remarks>Based on https://stackoverflow.com/questions/4181198/how-to-hash-a-password/10402129 Author is Christian Gollhardt</remarks>
	internal sealed class SecurePasswordHasher
	{
		private static readonly string hashPrefix = "$PWDHSH$V0$";

		/// <summary>
		/// Size of salt
		/// </summary>
		private const int SaltSize = 16;

		/// <summary>
		/// Size of hash
		/// </summary>
		private const int HashSize = 20;

		/// <summary>
		/// Creates a hash from a password
		/// </summary>
		/// <param name="password">the password</param>
		/// <param name="iterations">number of iterations</param>
		/// <returns>the hash</returns>
		private static string Hash(string password, int iterations)
		{
			//create salt
			byte[] salt;
			new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

			//create hash
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
			var hash = pbkdf2.GetBytes(HashSize);

			//combine salt and hash
			var hashBytes = new byte[SaltSize + HashSize];
			Array.Copy(salt, 0, hashBytes, 0, SaltSize);
			Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

			//convert to base64
			var base64Hash = Convert.ToBase64String(hashBytes);

			//format hash with extra information
			return $"{hashPrefix}{iterations}${base64Hash}";
		}

		/// <summary>
		/// Creates a hash from a password with 10000 iterations
		/// </summary>
		/// <param name="password">the password</param>
		/// <returns>the hash</returns>
		/// <remarks>Accept empty passwords</remarks>
		public static string Hash(string password)
		{
			//check empty
			if (string.IsNullOrEmpty(password)) return "";
			return Hash(password, 10000);
		}

		/// <summary>
		/// Check if hash is supported
		/// </summary>
		/// <param name="hashString">the hash</param>
		/// <returns>is supported?</returns>
		public static bool IsHashSupported(string hashString)
		{
			return hashString.Contains(hashPrefix);
		}

		/// <summary>
		/// Verify a password against a hash
		/// </summary>
		/// <param name="password">the password</param>
		/// <param name="hashedPassword">the hash</param>
		/// <returns>could be verified?</returns>
		/// <remarks>Accept empty passwords</remarks>
		public static bool Verify(string password, string hashedPassword)
		{
			//check empty
			if (string.IsNullOrEmpty(password) && string.IsNullOrEmpty(hashedPassword)) return true;
			if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(hashedPassword)) return false;

			//check hash
			if (!IsHashSupported(hashedPassword))
			{
				throw new NotSupportedException("The hashtype is not supported");
			}

			//extract iteration and Base64 string
			var splittedHashString = hashedPassword.Replace(hashPrefix, "").Split('$');
			var iterations = int.Parse(splittedHashString[0]);
			var base64Hash = splittedHashString[1];

			//get hashbytes
			var hashBytes = Convert.FromBase64String(base64Hash);

			//get salt
			var salt = new byte[SaltSize];
			Array.Copy(hashBytes, 0, salt, 0, SaltSize);

			//create hash with given salt
			var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
			byte[] hash = pbkdf2.GetBytes(HashSize);

			//get result
			for (var i = 0; i < HashSize; i++)
			{
				if (hashBytes[i + SaltSize] != hash[i])
				{
					return false;
				}
			}

			return true;
		}
	}
}