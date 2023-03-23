using DataEF;

namespace Core
{
    internal class OnInitDbFiller
    {
        AppDbContext _dbContext;
        public OnInitDbFiller(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void FillDb()
        {
            var st1 = new ServiceType()
            {
                Id = 1,
                ServiceTypeName = "ХВС"
            };
            var st2 = new ServiceType()
            {
                Id = 2,
                ServiceTypeName = "ЭЭ"
            };
            var st3 = new ServiceType()
            {
                Id = 3,
                ServiceTypeName = "ЭЭ День"
            };
            var st4 = new ServiceType()
            {
                Id = 4,
                ServiceTypeName = "ЭЭ Ночь"
            };
            var st5 = new ServiceType()
            {
                Id = 5,
                ServiceTypeName = "ГВС Теплоноситель"
            };
            var st6 = new ServiceType()
            {
                Id = 6,
                ServiceTypeName = "ГВС Тепловая энергия"
            };

            var dbCw = new Rate() 
            {
                Id = 1,
                Cost = 35.78m, 
                Normative = 4.85m,
                ServiceType = 1
            };

            var eeDb = new Rate()
            {
                Id = 2,
                Cost = 4.28m,
                Normative = 164m,
                ServiceType = 2
            };

            var eeDayDb = new Rate()
            {
                Id = 3,
                Cost = 4.9m,
                Normative = 0,
                ServiceType = 3
            };

            var eeNightDb = new Rate()
            {
                Id = 4,
                Cost = 2.31m,
                Normative = 0,
                ServiceType = 4
            };

            var hcDb = new Rate()
            {
                Id = 5,
                Cost = 35.78m,
                Normative = 4.01m,
                ServiceType = 5
            };

            var teDb = new Rate()
            {
                Id = 6,
                Cost = 998.69m,
                Normative = 0.05349m,
                ServiceType = 6
            };

            _dbContext.ServiceTypes.Add(st1);
            _dbContext.ServiceTypes.Add(st2);
            _dbContext.ServiceTypes.Add(st3);
            _dbContext.ServiceTypes.Add(st4);
            _dbContext.ServiceTypes.Add(st5);
            _dbContext.ServiceTypes.Add(st6);

            _dbContext.Rates.Add(dbCw);
            _dbContext.Rates.Add(eeDb);
            _dbContext.Rates.Add(eeDayDb);
            _dbContext.Rates.Add(eeNightDb);
            _dbContext.Rates.Add(hcDb);
            _dbContext.Rates.Add(teDb);

            _dbContext.SaveChanges();
        }
    }
}
