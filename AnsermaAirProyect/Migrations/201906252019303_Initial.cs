namespace AnsermaAirProyect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        price = c.Single(nullable: false),
                        passengerId = c.Int(nullable: false),
                        weight = c.Single(),
                        size = c.Single(),
                        seatCod = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Passengers", t => t.passengerId, cascadeDelete: true)
                .Index(t => t.passengerId);
            
            CreateTable(
                "dbo.Passengers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        lastName = c.String(),
                        flightId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Flights", t => t.flightId, cascadeDelete: true)
                .Index(t => t.flightId);
            
            CreateTable(
                "dbo.Flights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        departureDateTime = c.DateTime(nullable: false),
                        departureStation = c.String(),
                        arrivalStation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Services", "passengerId", "dbo.Passengers");
            DropForeignKey("dbo.Passengers", "flightId", "dbo.Flights");
            DropIndex("dbo.Passengers", new[] { "flightId" });
            DropIndex("dbo.Services", new[] { "passengerId" });
            DropTable("dbo.Flights");
            DropTable("dbo.Passengers");
            DropTable("dbo.Services");
        }
    }
}
