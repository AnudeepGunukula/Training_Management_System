

create database TrainingDb


use TrainingDb


select * from Attendences;


insert into TrainingDetails values('DotNet_Training','.Net','2021-08-08',31*24,'31days','2021-09-09','Full-Time')
insert into TrainingDetails values('Javascript_Training','Javascript','2021-08-01',15*24,'15days','2021-08-16','Full-Time')


select * from TrainingDetails;


insert into Trainees values('microsoft','Fulltime','2021-08-08',100,0,1,1)

insert into Trainees values('oracle','Fulltime','2021-08-01',100,0,1,2)

select * from Trainees

insert into Attendences values ('karthik','DotNet_Training',1,'2021-08-08',2)

insert into Attendences values ('Narendra','Javascript_Training',1,'2021-08-01',3)


select * from Attendences

-----------------------------------------------------------------------------------------------------------

create procedure selecttrainingDetails 
as 
select * from TrainingDetails;

exec selecttrainingDetails




Create procedure insertTrainingDetails  @trainingname varchar(30) , @technology varchar(30), @startdate DateTime,@durationinhours int,@totalduration varchar(30),@enddate DateTime,@trainingtype varchar(30)
as
insert into TrainingDetails([TrainingName],[Technology],[ExpectedStartDate],[ExpectedDurationInHours],[TotalDuration],[ExpectedEndDate],[TrainingType]) values 
(@trainingname,@technology,@startdate,@durationinhours,@totalduration,@enddate,@trainingtype)


exec insertTrainingDetails @trainingname='test',@technology='.test',@startdate='2021-08-08',@durationinhours=384,@totalduration='31days',@enddate='2021-09-09',@trainingtype='Full-time';







Create procedure updateTrainingDetails  @trainingname varchar(30) , @technology varchar(30), @startdate DateTime,@durationinhours int,@totalduration varchar(30),@enddate DateTime,@trainingtype varchar(30),@trainingId int
as
update TrainingDetails set [TrainingName]=@trainingname,[Technology]=@technology,[ExpectedStartDate]=@startdate,[ExpectedDurationInHours]=@durationinhours,[TotalDuration]=@totalduration,
  [ExpectedEndDate]=@enddate,[TrainingType]=@trainingtype where [TrainingId]=@trainingId;


drop procedure updateTrainingDetails

exec updateTrainingDetails  @trainingname='DotNet_Training',@technology='.Net',@startdate='2021-08-08',@durationinhours=1000,@totalduration='31days',@enddate='2021-09-09',@trainingtype='Full-time',@trainingId=4;




create procedure deleteTrainingDetails  @trainingId int
as
delete from TrainingDetails where [TrainingId]=@trainingId;


exec deleteTrainingDetails @trainingId=6


-----------------------------------------------------------------------------------------------------------------------


create procedure selectTrainees 
as 
select * from Trainees;
 
exec selectTrainees
 
 
 
 
Create procedure insertTrainees  @CertificationType nvarchar(max) , @TrainingType nvarchar(max), @TrainingFrom nvarchar(max),@Score int,@IsCertified bit,@NumberOfAttempt int,@TrainingId int
as
insert into Trainees([CertificationType],[TrainingType],[TrainingFrom],[Score],[IsCertified],[NumberOfAttempt],[TrainingId]) values 
(@CertificationType,@TrainingType,@TrainingFrom,@Score,@IsCertified,@NumberOfAttempt,@TrainingId)
 

exec insertTrainees @CertificationType='test',@TrainingType='.test',@TrainingFrom='2021-08-08',@Score=384,@IsCertified=1,@NumberOfAttempt=3,@TrainingId=1;
 
 
Create procedure updateTrainees @EmpId int, @CertificationType nvarchar(max) , @TrainingType nvarchar(max), @TrainingFrom nvarchar(max),@Score int,@IsCertified bit,@NumberOfAttempt int,@TrainingId int
as
update Trainees set [CertificationType]=@CertificationType,[TrainingType]=@TrainingType,[TrainingFrom]=@TrainingFrom,[Score]=@Score,[IsCertified]=@IsCertified,
  [NumberOfAttempt]=@NumberOfAttempt,[TrainingId]=@TrainingId where [EmpId]=@EmpId;
 

exec updateTrainees   @CertificationType='test',@TrainingType='.test',@TrainingFrom='2021-08-08',@Score=22222,@IsCertified=1,@NumberOfAttempt=3,@TrainingId=1,@EmpId=5;
 
 
create procedure deleteTrainees  @EmpId int
as
delete from Trainees where [EmpId]=@EmpId;
  
exec deleteTrainees @EmpId=5
 


 --------------------------------------------------------------------------------------------------------------------------------------------


 create procedure selectAttendences 
as 
select * from Attendences;
 
exec selectAttendences
 
 
 
Create procedure insertAttendences  @TraineeName nvarchar(30) , @TrainingName nvarchar(30), @Attendance bit ,@Date DateTime,@EmpId int
as
insert into Attendences([TraineeName],[TrainingName],[Attendance],[Date],[EmpId]) values 
(@TraineeName,@TrainingName,@Attendance,@Date,@EmpId)
 
 
exec insertAttendences @TraineeName='kartikeya',@TrainingName='Javascript_Training',@Attendance=1,@Date='2021-08-08',@EmpId=2;
 
 
Create procedure updateAttendences   @TraineeName nvarchar(30) , @TrainingName nvarchar(30), @Attendance bit ,@Date DateTime,@EmpId int,@Id int
as
update Attendences set [TraineeName]=@TraineeName,[TrainingName]=@TrainingName,[Attendance]=@Attendance,[Date]=@Date,[EmpId]=@EmpId where [Id]=@Id;
 
 select * from Attendences
 
exec updateAttendences  @TraineeName='gupta',@TrainingName='.Javascript_Training',@Attendance=1,@Date='2021-08-01',@EmpId=3,@Id=4;
 
 
 
create procedure deleteAttendences  @Id int
as
delete from Attendences where [Id]=@Id;
 
 
exec deleteAttendences @Id=4
-----------------------------------------------------------------------------------------------------------------------------------------
 
 
 

