# identityCustomMvc
.Net Core MVC Web Uygulamalarında Yetkilendirme - 2 (Custom Identity)

#### Örnek Veri tabanınızın (MSSQL) tablolarını oluşturmak için aşağıdaki SQL kodlarını kullanabilirsiniz.

```sql
CREATE TABLE dbo.YemekTarifleri
(
    Id       int identity
        constraint PK_YemekTarifleri
            primary key,
    YemekAdi nvarchar(max),
    Yapilisi nvarchar(max)
)
GO

SET IDENTITY_INSERT dbo.YemekTarifleri ON
INSERT INTO dbo.YemekTarifleri (Id, YemekAdi, Yapilisi) VALUES (1, 'Tam İstediğiniz Kıvamda: Kakaolu Islak Kek Tarifi', 'Kek tarifleri arasından ıslak keki çok seviyor, ama şimdiye kadar ıslak kek tarifinin yapılışını bilmiyorsanız veya denemediyseniz size harika bir ıslak kek tarifimiz var!

Unun olabildiği, yumurtanın desteğe gelebildiği, kakaonun sevebildiği en güzel yemek tariflerinden biri kakaolu ıslak kek. İlk gördüğün andan itibaren çatalın koca bir parçasına batırmak istersin. Misafir gelse ilk onu çıkarmak, evde tek başına kalsan sürekli yemek istersin.

Çocukluğumuzdan beri severek tükettiğimiz kakaolu ıslak kek, yapımında ayrılan sıvı kek harcının yarattığı akışkan kıvamdan dolayı farklı ve leziz bir deneyim yaşatırken aşk acısı başta olmak üzere her türlü acıya iyi geliyor. Kakaolu ıslak tarifinde hemen hemen her evde ve el altında bulunan malzemeler yer alıyor.

Bol soslu bu çikolatalı kolay ıslak kek tarifi çikolatalı pasta tariflerine kafa tutuyor, brownie kek tarifleriyle yarışıyor. Akışkan mı akışkan çikolatalı sosun nasıl yapıldığından ıslak kekin yapılış adımlarına her şeyi adım adım görsellerle anlatıyor, bununla da yetinmiyor, en güzel kakaolu ıslak kek tarifi video olarak da sizinle paylaşıyoruz.

Demleyin çayları, misafirliğe geleceğiz elimizde keklerle.');
INSERT INTO dbo.YemekTarifleri (Id, YemekAdi, Yapilisi) VALUES (2, 'Gün Lezzetlerinin Şahı: Kısır Tarifi', 'El altında bulunan belli başlı malzemeler ile kısa sürede hazırlanan, besleyici, renkli mi renkli, gün lezzetlerinin olmazsa olmazı kısır tarifi ile karşınızdayız bugün. Yemek tariflerinin altın gününe en çok yakışanı olur aynı zamanda kendisi. ''En güzel kısır tarifi benimki!'' demek için bu tarifi defterinize mutlaka kaydedin deriz.

Biliyoruz aklınızda "Evde kısır nasıl yapılır?", "Kısır hangi bulgurla yapılır?", "En güzel kısır nasıl yapılır?" gibi sorular var. Tam ölçülü ve sadece 10 dakikada hazır olan, yedikçe yediren kısır tarifimizde kısır yapmanın tüm püf noktalarını bulacak, adım adım resimli anlatımı sayesinde mutfakta hiç de zorlanmayacaksınız.

Çay demlenmeden hazır olan bu çok pratik kısır tarifine öyleyse buyursunlar...');
INSERT INTO dbo.YemekTarifleri (Id, YemekAdi, Yapilisi) VALUES (3, 'Zamansız Çorba: Mercimek Çorbası Tarifi', 'Yaz kış demeden her mevsim, her zaman, her durumda elimizin gittiği tariftir mercimek çorbası tarifi. En çok sevilen çorbalardan biridir o! Bu yüzden zamansız çorbadır. Belki de bütün yemek tarifleri için böyledir.

Hatta ezogelin çorbasıyla olan mücadelesini bir kenara koyarsanız, zamansız çorbaların en güzeli, en birincisi. Bunları söylüyoruz çünkü şimdiye kadar "en güzel mercimek çorbası" tarifini arayıp bulamadıysanız lezzetli ve pratik bu tencerede mercimek çorbası yapımı tam size göre!

Lafı uzatmadan ''Mercimek çorbası nasıl yapılır?'', "Mercimek çorbası nasıl pişirilir?" diye merak edenleri ev yapımı mercimek çorbası tarifimize alalım. Adım adım resimli anlatımı ve videosuyla her eve mis gibi kokan, şifalı mercimek çorbasını davet edelim.

Afiyetler olsun diyelim, eğer sizin de kendinize özel mercimek çorbası pişirme yöntemleriniz varsa yorumlarda tüm okuyucularımızla paylaşmanızı isteyelim.

Not: "Mercimek çorbası tamam da ben daha fazla çorba çeşidi de görmek istiyorum" diyenleri şöyle alalım: Çorba Tarifleri!');
SET IDENTITY_INSERT dbo.YemekTarifleri OFF
GO

CREATE TABLE dbo.[__EFMigrationsHistory]
(
    MigrationId    nvarchar(150) not null
        constraint PK___EFMigrationsHistory
            primary key,
    ProductVersion nvarchar(32)  not null
)
GO

SET IDENTITY_INSERT dbo.__EFMigrationsHistory ON
INSERT INTO dbo.__EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190626205030_InitialCommit', '2.2.4-servicing-10062');
INSERT INTO dbo.__EFMigrationsHistory (MigrationId, ProductVersion) VALUES ('20190626212925_Initial', '2.2.4-servicing-10062');
SET IDENTITY_INSERT dbo.__EFMigrationsHistory OFF
GO
```

