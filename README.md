# WebApi (uygulama default kullanıcı adı : "admin" şifre: "1234" )
Örnek uygulamada kullanılan teknolojiler 
  - örnek veriler "https://jsonplaceholder.typicode.com/users" adresinden temin edilmiştir.
  - servis odaklı mimari(Soa) yaklaşımı kullanılarak geliştirilmiştir.
  - DotNet Core 3.1 
  - Veritabanı olarak Sql-server (microsoft.com/mssql/server:2017-latest-ubuntu)
  - Cache olarak Redis 
  - Görüntüleme için Swagger
  - Uygulamanın çalıştırılma ortamı olarak Docker 
  - Dependincy  injection
  - Entity Framework ile Code-First
  - Dto(data transfer object) ve Mapper 
  
Uygulama çalışma yapısı

uygulamanın hatasız çalışabilmesi için proje indirildikten sonra
  - powershell kullanılarak "docker compose" çalıştırılması ile dockere gerekli uygulamaların yüklenmesi gerçekleştirilmektedir.
  - gerekli yüklemeler sonucunda uygulama ayağa kaltığında "http://localhost:5050/swagger/index.html" linkinden APİ ulaşılabilir olmaktadır.
  - api icerigine ulaşabilmek için yetki(dogrulama) işlemi gerekmektedir.
  - uygulamada cache işlemi sadece bütün bölümünde aktif olarak çalışmaktadır.

