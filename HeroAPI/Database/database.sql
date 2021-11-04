CREATE DATABASE heroGame;
USE heroGame;
delete 
from Hero 
delete 
from Villian 
delete 
from Game 
delete 
from TurnTaken 
select * from hero 
select * from villian
select * from Game
select * from TurnTaken  
create table Hero(
    HeroID int,
    HeroName Nvarchar(100), 
    MinDice int,
    MaxDice int, 
    Uses int,
    PRIMARY KEY (HeroID)
)

create table Villian(
    VillianID int,
    VillianName Nvarchar(100),
    AttackPoints int,
    primary key (VillianID)
)

create table Game(
    GameID int,
    Primary Key (GameID)
)

create table TurnTaken (
    TurnNo int,
    HeroID int,
    VillianID int,
    GameID int,
    DamageDelt int,
    Primary Key (TurnNo, HeroID, VillianID, GameID),
    Foreign Key (HeroID) References Hero,
    Foreign Key (VillianID) References Villian,
    Foreign key (GameID) References Game
)

insert into Hero(HeroID, HeroName, MinDice, MaxDice, Uses) Values 
(1, 'jim', 1, 9, 1),
(2, 'timmy', 1, 4, 5),
(3, 'wimmy', 6, 7, 3),
(4, 'qimmy', 3, 6, 7);


insert into Villian (VillianID, VillianName, AttackPoints) values 
(4, 'NotEvil', 5),
(3, 'StillNotEvil', 5),
(2, 'AmEvil', 5),
(1, 'Agam', 1);

insert into Game (GameID) values 
(1);

insert into TurnTaken (TurnNo, HeroID, VillianID, GameID, DamageDelt) values
(1, 3, 4, 1, 0)


/*Stored Procs Baby*/
--Hero Stuff-- 
--delete 
if object_id('DeleteHero') is not null 
drop procedure DeleteHero;

go 
create procedure DeleteHero
    @delHeroId int
as 
begin 
    begin try 
    delete from Hero

    where @delHeroId = HeroID
end try 
begin catch 
end catch 
end 

--update
go
if object_id('HeroPut') is not null 
drop procedure HeroPut;

go 
create procedure HeroPut 
    @putHeroID int,
    @putHeroName nvarchar(100),
    @putMinDice int,
    @putMaxDice int, 
    @putUses int

as 
begin 
begin try 
    update Hero 
    set HeroID = @putHeroID, 
        HeroName = @putHeroName,
        MinDice = @putMinDice, 
        MaxDice = @putMaxDice,
        Uses = @putUses
    where HeroID = @putHeroID
end try 
begin catch 
end catch 
end 

--post
go
if object_id('HeroPost') is not null 
drop procedure HeroPost;

go 
create procedure HeroPost
    @postHeroID int,
    @postHeroName nvarchar(100),
    @postMinDice int,
    @postMaxDice int, 
    @postUses int
as 
begin
    begin try 
    insert into Hero (HeroID, HeroName, MinDice, MaxDice, Uses )
    values ( @postHeroID, @postHeroName, @postMinDice, @postMaxDice, @postUses)
end try 
begin catch 
end catch 
end

--Villian Stuff-- 
--post
IF OBJECT_ID('PostVillian') is not null 
    DROP PROCEDURE PostVillian;

go
CREATE PROCEDURE PostVillian
    @postVillainID INT,
    @postVillianName NVARCHAR(100),
    @postAttackpoints INT

as 
begin 
    begin try 
    insert into Villian (VillianID, VillianName, AttackPoints)
    values (@postVillainID, @postVillianName, @postAttackpoints)
    end try 
begin catch 
end catch 
end 
go 


-- update Villain
if object_id('UpdateVillian') is not NULL
drop procedure UpdateVillian

go 
create procedure UpdateVillian
@putVillianID int,
@putVillianName nvarchar(100),
@putVillianUses int
as 
begin
    begin try 
    update Villian set VillianID = @putVillianID, VillianName = @putVillianName, Uses = @putVillianUses
    where VillianID = @putVillianID
end try 
begin catch 
end catch 
end


-- DELETE Villain
if OBJECT_ID('DeleteVillain') is not null
    drop procedure DeleteVillain;

GO
CREATE PROCEDURE DELETE_Villain
    @delVillainID INT
AS
BEGIN
    BEGIN TRY
    DELETE FROM Villian
       WHERE VillainID = @delVillainID
    END TRY
    BEGIN CATCH
    END CATCH
END
GO

-- Post GAME 
if object_id('GamePost') is not null
drop procedure GamePost

go 
create procedure GamePost
 @postID int
as 
begin 
    begin try 
    insert into Game (GameID)
    values (@postID)
    end try 
begin catch 
end catch 
end



--     create table Hero(
--     HeroID int,
--     HeroName Nvarchar(100), 
--     MinDice int,
--     MaxDice int, 
--     Uses int,
--     PRIMARY KEY (HeroID)
