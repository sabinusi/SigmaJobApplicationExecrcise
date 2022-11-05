using SigmaJobApplicantion.Helper.Interfaces;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using SigmaJobApplicantion.Model;

namespace SigmaJobApplicantion.Helper;

public class ApplicantRepository:IApplicationRepository
{
        public string RecordFile { get; set;}
   

    public ApplicantRepository(IConfiguration configuration)
    {
        
      RecordFile = configuration.GetSection("ApplicantRecordFile").Value;
    }
    
    public void AddEntity(Applicant entity)
    {
        var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };
      
        using (var stream =  System.IO.File.Open(RecordFile, FileMode.Append))
        using (var writer = new StreamWriter(stream))
        using (var csv = new CsvWriter(writer, configPersons))
        {
            csv.Context.RegisterClassMap<ApplicantMap>();
            csv.WriteRecord(entity);
        }

    }

    public bool UpdateEnttity(Applicant entity)
    {
        List<Applicant> applicants = new List<Applicant>();
        bool foundRecordToUpdate = false;
        var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };
      
        // using (var stream =  System.IO.File.Open("ApplicantRecords.csv", FileMode.Append))
        using (var writer = new StreamReader(RecordFile))
        using (var csv = new CsvReader(writer,configPersons))
        {
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                Applicant  applicantRecord = csv.GetRecord<Applicant>();
                if ( applicantRecord.Email == entity.Email)
                {
                    
                
                    applicants.Add(entity);
                    foundRecordToUpdate = true;

                }
                else
                {
                    applicants.Add(applicantRecord);
                }
                
            }
        }

        if (foundRecordToUpdate)
        {
            AddAllEntity(applicants);
            return true;
        }

        return false;
    }

    public void AddAllEntity(List<Applicant> entities)
    {
        var configPersons = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };


        using (var writer = new StreamWriter(RecordFile))
        using (var csv = new CsvWriter(writer, configPersons))
        {
            csv.Context.RegisterClassMap<ApplicantMap>();
            csv.WriteRecords<Applicant>(entities);


        }
    }
}