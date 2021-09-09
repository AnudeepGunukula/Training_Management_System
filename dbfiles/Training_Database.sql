
use TrainingDb


select * from Attendences;


insert into TrainingDetails values('DotNet_Training','.Net','2021-08-08',31*24,'31days','2021-09-09','Full-Time')
insert into TrainingDetails values('Javascript_Training','Javascript','2021-08-01',15*24,'15days','2021-08-16','Full-Time')


select * from TrainingDetails;


insert into Trainees values('microsoft','Fulltime','2021-08-08',100,0,1,3)

insert into Trainees values('oracle','Fulltime','2021-08-01',100,0,1,4)

select * from Trainees

insert into Attendences values ('karthik','DotNet_Training',1,'2021-08-08',1)

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