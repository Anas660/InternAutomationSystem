
CREATE procedure BIRIM_SELECTLIST
AS

BEGIN

SELECT
 s.DepartmanId,p.DepartmanAdi,s.AnlikSayi,S.KontenjanSayisi from StajyerKontanjan s
INNER JOIN  PersonelDepartman p on s.DepartmanId = p.PersonelDepartmanId

end

go 

CREATE PROC BOLUM_DELETE
@ID INT
AS
DELETE FROM Bolum WHERE BolumId = @ID

go

CREATE PROC BOLUM_INSERT
@BOLUMADI NVARCHAR(250)
AS
INSERT INTO Bolum (BolumAdi) VALUES (@BOLUMADI)

go 

CREATE PROC BOLUM_SELECT
@ID INT
AS
SELECT * FROM Bolum WITH(NOLOCK) WHERE BolumId = @ID

go 
CREATE PROC BOLUM_SELECTLIST
AS
SELECT * FROM Bolum WITH(NOLOCK)

go 


CREATE PROC BOLUM_UPDATE
@ID INT,
@BOLUMADI NVARCHAR(250)
AS
UPDATE Bolum SET BolumAdi = @BOLUMADI WHERE BolumId = @ID

go

CREATE PROC OKUL_DELETE
@ID INT
AS
DELETE FROM Okul WHERE OkulId = @ID

go 

CREATE PROC OKUL_INSERT
@OKULADI NVARCHAR(250)
AS
INSERT INTO Okul (OkulAdi) VALUES (@OKULADI)

go 

CREATE PROC OKUL_SELECT
@ID INT
AS
SELECT * FROM Okul WITH(NOLOCK) WHERE OkulId = @ID

go 

CREATE PROC OKUL_SELECTLIST
AS
SELECT * FROM Okul WITH(NOLOCK)

go 

CREATE PROC OKUL_UPDATE
@ID INT,
@OKULADI NVARCHAR(250)
AS
UPDATE Okul SET OkulAdi = @OKULADI WHERE OkulId = @ID

go


CREATE Procedure dbo.spAnlikSayiArtir
	@DepartmanId int = 0
AS
BEGIN
   BEGIN TRANSACTION trans
    declare @anlikSayi int	

	set @anlikSayi =(SELECT AnlikSayi from StajyerKontanjan where DepartmanId = @DepartmanId)

	update StajyerKontanjan set AnlikSayi = @anlikSayi+1 where DepartmanId = @DepartmanId

END
    IF(@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION trans
    RETURN;
END
    COMMIT TRANSACTION trans

	go

	CREATE Procedure dbo.spAnlikSayiAzalt
	@DepartmanId int = 0
AS
BEGIN
   BEGIN TRANSACTION trans
    declare @anlikSayi int	

	set @anlikSayi =(SELECT AnlikSayi from StajyerKontanjan where DepartmanId = @DepartmanId)

	update StajyerKontanjan set AnlikSayi = @anlikSayi-1 where DepartmanId = @DepartmanId

END
    IF(@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION trans
    RETURN;
END
    COMMIT TRANSACTION trans

	go

	Create Procedure STAJYER_DELETE
@STAJYERID int
AS
BEGIN
   BEGIN TRANSACTION trans

    DELETE PersonelStajyer WHERE [StajyerId] = @STAJYERID 

    IF(@@ERROR <> 0)
    BEGIN
        ROLLBACK TRANSACTION trans
        RETURN;
    END
    COMMIT TRANSACTION trans
END

go

CREATE proc STAJYER_INSERT
@OKULID INT,
@BOLUMID INT,
@STAJYERADI NVARCHAR(150) ,
@STAJYERSOYADI NVARCHAR(150),
@TELEFON NVARCHAR(50) ,
@EMAIL NVARCHAR(50),
@ADRES NVARCHAR(250) ,
@DOGUMYERI NVARCHAR(150),
@DOGUMTARIHI DATETIME ,
@TCNO NVARCHAR(50) ,
@SICILNO NVARCHAR(50),
@BASLAMATARIHI DATETIME ,
@BITISTARIHI DATETIME,
@DEPARTMANID INT
AS
BEGIN
   BEGIN TRANSACTION trans
    	declare @SistemTarihi datetime = getdate();
    INSERT INTO PersonelStajyer
        ([OkulId],[BolumId],[Adi], [Soyadi],[Telefon] , [Email],[Adres] , [DogumYeri], [DogumTarihi],[TcNo],[SicilNo],[BaslamaTarihi],[BitisTarihi],[DepartmanId])
    VALUES
        (@OKULID,@BOLUMID,@STAJYERADI, @STAJYERSOYADI, @TELEFON, @EMAIL, @ADRES, @DOGUMYERI, @DOGUMTARIHI,@TCNO,@SICILNO,@BASLAMATARIHI,@BITISTARIHI,@DEPARTMANID)
		IF(@@ERROR <> 0)
    BEGIN
        ROLLBACK TRANSACTION trans
        RETURN;
    END
    COMMIT TRANSACTION trans
END

go

CREATE Procedure STAJYER_SELECT
@STAJYERID int
AS
BEGIN

SELECT StajyerId ,[OkulId], [BolumId],[Adi], [Soyadi], [Telefon], [Email], [Adres], [DogumYeri], [DogumTarihi], [TcNo], [SicilNo], [BaslamaTarihi], [BitisTarihi], [DepartmanId] FROM PersonelStajyer WHERE [StajyerId]=@STAJYERID

END

go

CREATE Procedure STAJYER_SELECTLIST
AS
BEGIN

SELECT p.StajyerId, p.OkulId,o.OkulAdi, p.BolumId,b.BolumAdi,p.Adi ,p.Soyadi ,p.Telefon,p.[Email], p.[Adres], p.[DogumYeri], p.[DogumTarihi], p.[TcNo], p.[SicilNo], p.[BaslamaTarihi], p.[BitisTarihi], p.[DepartmanId],pd.DepartmanAdi FROM PersonelStajyer p
INNER JOIN Okul o ON o.OkulId = p.OkulId
INNER JOIN Bolum b ON b.BolumId = p.BolumId
INNER JOIN PersonelDepartman pd ON pd.PersonelDepartmanId = p.DepartmanId

END

go

CREATE proc STAJYER_UPDATE
@OKULID INT,
@BOLUMID INT,
@STAJYERID INT,
@STAJYERADI NVARCHAR(150) ,
@STAJYERSOYADI NVARCHAR(150),
@TELEFON NVARCHar(50) ,
@EMAIL NVARCHAR(50),
@ADRES NVARCHAR(250) ,
@DOGUMYERI NVARCHAR(150),
@DOGUMTARIHI DATETIME ,
@TCNO NVARCHar(50) ,
@SICILNO NVARCHAR(50),
@BASLAMATARIHI DATETIME ,
@BITISTARIHI DATETIME,
@DEPARTMANID INT
AS
BEGIN
 BEGIN TRANSACTION trans
    UPDATE PersonelStajyer  
       SET [Adi] = @STAJYERADI , [Soyadi] = @STAJYERSOYADI,[Telefon] = @TELEFON, [Email] = @EMAIL ,[Adres] = @ADRES, [DogumYeri] = @DOGUMYERI, [DogumTarihi]=@DOGUMTARIHI, [TcNo]=@TCNO, [SicilNo]=@SICILNO, [BaslamaTarihi]=@BASLAMATARIHI, [BitisTarihi]=@BITISTARIHI,[DepartmanId]=@DEPARTMANID,[OkulId]=@OKULID, [BolumId]=@BOLUMID
	WHERE [StajyerId] = @STAJYERID 
END
IF(@@ERROR <> 0)
BEGIN
    ROLLBACK TRANSACTION trans
    RETURN;
END
    COMMIT TRANSACTION trans