# WebApi
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
  - Default olarak her kullanıcının rolü = User ve şifresi 1234 olarak atanmaktadır.
  - Uygulama Default olarak bir Admin kullanıcısı bulunmaktadır. Bu kullanıcının adı = admin şifresi = 1234 rolü = Admin dir.
  - Uygulamada iki tür kullanıcı rolü bulunmaktadır. Bunlar Admin ve User rolleridir. Admin uygulamada tüm işlemlere yetkili roldür. User ise Users ve Auth bölümünde tam yetkili diğer bölümlerde ise sadece verileri görüntüleme yetkilerine sahiptir.
  - Rol ve şifre değiştirme işi Auth bölümünden yapılabilmektedir.
  - yeni bir kullanıcı oluşturuldugunda, yeni kullanıcı için default olarak rolü = User olarak atanır. 
  - şifre veya rolde değişiklik yapmak isteniyorsa Auth bölümünden değişiklikler yapılabilir.
  - uygulamada cache işlemi bütün bölümünde aktif olarak çalışmaktadır.
  - Uygulama 500 hatasını veriyorsa UNİQUE alanlara aynı verileri girmeye çalışıyor olabilirsiniz veya birbirine baglı bölümlerde olmayan bir verini eklemeye çalışıyor olabilirsiniz. örnegin Company bölümünde olmayan bir company id yi userde ilgili bölüme girdiginizde hatayla karşılaşırsınız. 

