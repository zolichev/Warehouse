# Warehouse
Warehouse WebApi REST service.

### «апуск сервиса
 лонировать или скачать репозиторий. ќткрыть Warehouse.sln в Visual Studio 2017. 
ѕровести сборку решени€ и запустить решение, стартовый проект Warehouse.WebApi. ”бедитс€ что открыт адрес http://localhost:51205/swagger/ui/index.

ƒополнительно, запущенное приложение можно увидеть в облаке  - https://warehousewebapiservice.azurewebsites.net/swagger/ui/index

¬ приложении установлен swagger который позвол€ет видеть доступные веб сервисы и запускать их.

ƒл€ запуска запросов требующих аутентификации запросов используйте встроеного пользовател€ "test"/"" (пароль пустой), либо создайте нового с помощью метода: 
"post  /api/store/Clients  Register new client"

### ƒоступные запросы

Wares / “овары

* "get  /api/store/Wares  Get all wares in store" ѕолучить список всех товаров на складе
* "get  /api/store/Wares/{id}  Get ware by id." ѕолучить параметры товара по идентификатору
* "post  /api/store/Wares  Add new ware in store" ƒобавить новый товар на склад
* "delete  /api/store/Wares/{id}  Remove ware from store" ¬з€ть товар со скалада по идентификатору
* "delete  /api/store/Wares  Remove first expired ware from store" ¬з€ть товар, с самой ранней датой годности, со склада по указанному названию товара

Clients /  лиенты (пользователи)

* "get  /api/store/Clients  Get current client." ѕолучение информации по текущему клиенту
* "post  /api/store/Clients  Register new client" –егистраци€ нового клиента
* "put  /api/store/Clients  Update notifiable property of current client" ”становка нового значени€ требовани€ нотифицировани€ клиента

Notifications / ”ведомлени€

* "get  /api/store/Notifications  Get all notifications." ѕолучить все уведомлени€ дл€ текущего клиента
* "get  /api/store/Notifications/{id}  Get notification by id." ѕолучить параметры уведомлени€ по идентификатору
* "delete  /api/store/Notifications/{id}  View and remove notification from client" ѕолучить параметры уведомлени€ по идентификатору и пометить его просмотренным
* "post  /api/store/Notifications  View and make viewed next notification from client"  ѕолучить параметры следующего в очереди непросмотренного уведомлени€ и пометить его просмотренным
* "delete  /api/store/Notifications  View and make viewed all notifications from client" ѕолучить все непросмотренные уведомлени€ и пометить их просмотренными

