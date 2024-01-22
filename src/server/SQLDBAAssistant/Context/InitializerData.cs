using SQLDBAAssistant.Models.SQLiteModels;

namespace SQLDBAAssistant.Context
{
    public class InitializerData
    {
        public static void SeedData(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<MasterContext>();

            //Creating Primary Queries 
            if (!context.Queries.Any())
            {
                context.Queries.AddRange(
                new Query
                {
                    Id = 1,
                    idUser = 1,
                    TextQuery = "select scheduler_id, cpu_id, status, is_online from sys.dm_os_schedulers where status = 'VISIBLE ONLINE'",
                    Title = "AmountCPUCoresInUse"
                },
                new Query
                {
                    Id = 2,
                    idUser = 1,
                    TextQuery = "select name, compatibility_level, state_desc , create_date from sys.databases",
                    Title = "DatabasesList"
                },
                new Query
                {
                    Id = 3,
                    idUser = 1,
                    TextQuery = "select login_name, count(*) as amount from sys.dm_exec_sessions group by login_name ",
                    Title = "SessionLogins"
                },
                new Query
                {
                    Id = 4,
                    idUser = 1,
                    TextQuery = "SELECT req.start_time, login_name, pro.session_id, pro.status, pro.cpu_time, pro.reads, resource_description, " +
                                " last_request_end_time FROM sys.dm_tran_locks l LEFT JOIN sys.databases db ON db.database_id = l.resource_database_id" +
                                " LEFT JOIN sys.dm_exec_sessions pro ON pro.session_id = l.request_session_id" +
                                " LEFT JOIN sys.dm_exec_requests req ON req.session_id = pro.session_id" +
                                " WHERE pro.status = 'sleeping' ",
                    Title = "SessionSleeping"
                },
                new Query
                {
                    Id = 5,
                    idUser = 1,
                    TextQuery = "select status, count(*) as amount from sys.dm_exec_sessions group by status",
                    Title = "SessionStatus"
                    
                });

                context.SaveChanges();
            }
        }
    }
}
