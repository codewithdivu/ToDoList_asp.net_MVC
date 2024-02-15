namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialTodo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ToDoItems", "task", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ToDoItems", "task", c => c.String());
        }
    }
}
