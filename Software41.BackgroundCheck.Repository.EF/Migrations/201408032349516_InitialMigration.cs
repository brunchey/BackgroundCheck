namespace Software41.BackgroundCheck.Repository.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressHistory",
                c => new
                    {
                        AddressHistoryId = c.Int(nullable: false, identity: true),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        FromDate = c.String(),
                        ToDate = c.String(),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.AddressHistoryId)
                .ForeignKey("dbo.Applicant", t => t.Applicant_Id, cascadeDelete: true)
                .Index(t => t.Applicant_Id);
            
            CreateTable(
                "dbo.Applicant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EducationHistory",
                c => new
                    {
                        EducationHistoryId = c.Int(nullable: false, identity: true),
                        SchoolName = c.String(),
                        SchoolType = c.Int(nullable: false),
                        AttendedFrom = c.DateTime(nullable: false),
                        AttendedTo = c.DateTime(nullable: false),
                        Graduated = c.Boolean(nullable: false),
                        DegreeType = c.Int(nullable: false),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.EducationHistoryId)
                .ForeignKey("dbo.Applicant", t => t.Applicant_Id, cascadeDelete: true)
                .Index(t => t.Applicant_Id);
            
            CreateTable(
                "dbo.EmploymentHistory",
                c => new
                    {
                        EmploymentHistoryId = c.Int(nullable: false, identity: true),
                        EmployerName = c.String(),
                        JobTitle = c.String(),
                        Salary = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Applicant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.EmploymentHistoryId)
                .ForeignKey("dbo.Applicant", t => t.Applicant_Id, cascadeDelete: true)
                .Index(t => t.Applicant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmploymentHistory", "Applicant_Id", "dbo.Applicant");
            DropForeignKey("dbo.EducationHistory", "Applicant_Id", "dbo.Applicant");
            DropForeignKey("dbo.AddressHistory", "Applicant_Id", "dbo.Applicant");
            DropIndex("dbo.EmploymentHistory", new[] { "Applicant_Id" });
            DropIndex("dbo.EducationHistory", new[] { "Applicant_Id" });
            DropIndex("dbo.AddressHistory", new[] { "Applicant_Id" });
            DropTable("dbo.EmploymentHistory");
            DropTable("dbo.EducationHistory");
            DropTable("dbo.Applicant");
            DropTable("dbo.AddressHistory");
        }
    }
}
