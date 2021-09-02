# ASP.NET Core версии 5.0 RESTFul Web API для хранения и обновления списка книг в домашней библиотеке.

База данных: MongoDb 4.4

Добавлена JWT аутентификация для ограничения доступа к домашней библиотеке.

Пример и описание процесса запуска

# UserController

Для начала нужно создать пользователя: (https://localhost:44321/api/user/create POST Method)
![UserCreate](https://user-images.githubusercontent.com/60881062/131808143-1cb77dba-2ce5-47f3-a2a7-be6b8b6192cf.PNG)

Далее пройти аутентификацию для получение токена: (https://localhost:44321/api/user/authenticate POST Method)
![Authenticate](https://user-images.githubusercontent.com/60881062/131808499-b53fe31f-42af-4af2-b4af-5665b5c50474.PNG)

После получения токена можно получить доступ к методам BookController (добавив токен в header запроса)

Информация о всех зарегистрированных пользователей (добавить токен в header): (https://localhost:44321/api/user GET Method)
![UserGet](https://user-images.githubusercontent.com/60881062/131808816-d46358f8-73fa-4afe-bcaa-deb4f55bfaf4.PNG)

# BookController

Добавление книги в библиотеку: (https://localhost:44321/api/book POST Method)
![BookCreate](https://user-images.githubusercontent.com/60881062/131808944-11cb5877-b480-4634-96c7-e23b3ba773df.PNG)

Получение информации о книге: (https://localhost:44321/api/book/{id} GET Method)
![BookGetId](https://user-images.githubusercontent.com/60881062/131809073-a08e3ccd-5050-421c-b4fc-177344a92683.PNG)

Обновление информации по книге: (https://localhost:44321/api/book PUT Method)
![BookUpdate](https://user-images.githubusercontent.com/60881062/131809169-010dbdac-90b9-4a4b-b73b-5707b4d3adc6.PNG)

Получение списка книг по жанру: (https://localhost:44321/api/book/bygenre GET Method)
![BookByGenre](https://user-images.githubusercontent.com/60881062/131809642-94de059d-d043-4e71-a5c9-415a66c4055e.PNG)

Удаление книги из библиотеки: (https://localhost:44321/api/book/{id} DELETE Method)
![BookDelete](https://user-images.githubusercontent.com/60881062/131809490-6ffe534a-c18c-4b31-ae76-8f36cc620afd.PNG)

Получение списка книг: (https://localhost:44321/api/book GET Method)
![BookGet](https://user-images.githubusercontent.com/60881062/131810008-3c3dbcab-eb57-47c9-a177-5d1033d6eac2.PNG)
