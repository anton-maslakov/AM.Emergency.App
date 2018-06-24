Для того, чтобы запустить веб-приложение "Диспетчер МЧС" требуется выполнить следующие шаги:

Вам надо скачать данный репозиторий.
В папке AM.EmergencyService.Database запустить CreateDatabaseScript.sql для создания базы данных.
Вход осуществляется через Windows Authentication, по умолчанию база данных содаётся в директории: "C:\Program Files\Microsoft SQL Server", если требуется - измените путь в скрипте.
В файле: ~\AM.Emergency.App/AM.EmergencyService.App/AM.EmergencyService.App.Data/App.config, измените значение строки подключения. В этом же файле измените адрес WCF сервиса с рекламой, для её корректного отображения.
Веб-приложение готово для использования.
По умолчанию созданы пользователи: login: dispatcher password: dispatcher role:dispatcher; login: editor password: editor role:dispatcher, editor; login: admin password: admin role:dispatcher, editor, admin.
