# ProductTracking-ENTITY

Merhaba,
Bu projede entity framework kullanılmıştır. Projenize entity framework eklemek için VS2022 içerisinde projenizin de içinde yer aldığı sağ tarafta bulunan solution bölümünden projeye yeni öğe(new ıtem) eklenmesi gerekir. 
Bu listede bulunan data içerisinde ADO.NET Entity Data Model'in DB first yapısı kullanılmıştır. Tüm CRUD işlemleri bu şekilde organize edilmiştir. 
Ayrıca oluşturduğunuz bir DB yoksa dosyalar arasında bulunan DB'nin içeriğini, SQL Server Management Studio uygulamasının kurulu olduğu dizine gidip MSSQL içerisinde bulunan DATA klasörünün içerisine eklemelisiniz.

Tablolar arası ilişkiler:

TBLKATEGORI ID -> TBLURUN KATEGORI

TBLURUN URUNID -> TBLSATIS URUN

TBLMUSTERI MUSTERIID -> TBLSATIS MUSTERI

Eklenilen DB verileriyle beraber yukarıdaki ilişkiler gelmezse, ilgili database içerisinde diyagram kısmında yukarıdaki ilişkiler oluşturulmalıdır.

Ek olarak bu projede istatistik sayfası için prosedür kullanılmıştır.

DB ile prosedürün de gelmediği durumda,
CREATE PROCEDURE MARKAGETIR AS SELECT TOP 1 MARKA FROM TBLURUN GROUP BY MARKA ORDER BY COUNT(*) DESC
SQL üzerinden bu kod ile oluşturabilirsiniz.

Eğer kurulum konusunda sorun yaşarsanız bana mail adresimden ulaşabilirsiniz.

![image](https://github.com/OzcanFatihCan/ProductTracking-ENTITY/assets/93872480/64342869-3763-48c5-bbe1-759a07a730cc)
![image](https://github.com/OzcanFatihCan/ProductTracking-ENTITY/assets/93872480/21eb62f4-3343-43f1-885a-bdfc98675013)
![image](https://github.com/OzcanFatihCan/ProductTracking-ENTITY/assets/93872480/ab0c9fc2-fab2-4b13-9d5d-39ddde061ff2)
![image](https://github.com/OzcanFatihCan/ProductTracking-ENTITY/assets/93872480/18eafd5d-8c9b-4c0e-9317-462d0e5ce208)
![image](https://github.com/OzcanFatihCan/ProductTracking-ENTITY/assets/93872480/051d46c5-9292-436a-b092-d585111160dd)
![image](https://github.com/OzcanFatihCan/ProductTracking-ENTITY/assets/93872480/3fb0b7c5-62be-433f-bed1-332ddda87a56)

