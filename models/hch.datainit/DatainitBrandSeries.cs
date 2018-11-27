using hch.definition;
using hch.model;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.datainit
{
    public class DatainitBrandSeries : IDataInitializer
    {
        public string Table => "CarsBrandSeries";

        public int Build(IWxDbContext context, params string[] args)
        {
            using (var db = WxDbFactory.GetDbContext().MyDB)
            {
                if (db.Count<CarsBrandSeries>() == 0)
                {
                    var Audi = new CarsBrandSeries("奥迪", "A", "ad.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.Germany);
                    var BMW = new CarsBrandSeries("宝马", "B", "bm.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.Germany);
                    var Benz = new CarsBrandSeries("奔驰", "B", "bc.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.Germany);
                    var Porsche = new CarsBrandSeries("保时捷", "B", "bsj.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.Germany);
                    var Bentley = new CarsBrandSeries("宾利", "B", "bl.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.England);
                    var Toyota = new CarsBrandSeries("丰田", "F", "ft.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.Japanese);
                    var Volkswagen = new CarsBrandSeries("大众", "D", "dz.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.Germany);
                    var Infiniti = new CarsBrandSeries("英菲尼迪", "Y", "yfnd.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.Japanese);
                    var Lexus = new CarsBrandSeries("雷克萨斯", "L", "lkss.jpg", ValidityState.Enabled, CarBrandType.Hot, CarBrandCountry.Japanese);
                    var cbs = new List<CarsBrandSeries>() { Audi, BMW, Benz, Porsche, Bentley, Toyota, Volkswagen, Infiniti, Lexus };

                    var BrandSeries = new List<CarsBrandSeries>() {
                new CarsBrandSeries(Audi.Id,"A1(进口)",ValidityState.Enabled,CarSeriesGrade.Small),
                new CarsBrandSeries(Audi.Id, "A3",  ValidityState.Enabled, CarSeriesGrade.Compact),
                new CarsBrandSeries(Audi.Id, "A4L", ValidityState.Enabled, CarSeriesGrade.Middle),
                new CarsBrandSeries(Audi.Id, "A6L",  ValidityState.Enabled, CarSeriesGrade.MiddleLarge),
                new CarsBrandSeries(Audi.Id, "A8(进口)",  ValidityState.Enabled, CarSeriesGrade.Large),
                new CarsBrandSeries(Audi.Id, "Q5",  ValidityState.Enabled, CarSeriesGrade.SUV),

                new CarsBrandSeries(BMW.Id,"i3(进口)",ValidityState.Enabled,CarSeriesGrade.Small),
                new CarsBrandSeries(BMW.Id, "1系",  ValidityState.Enabled, CarSeriesGrade.Compact),
                new CarsBrandSeries(BMW.Id, "3系",  ValidityState.Enabled, CarSeriesGrade.Middle),
                new CarsBrandSeries(BMW.Id, "5系",  ValidityState.Enabled, CarSeriesGrade.MiddleLarge),
                new CarsBrandSeries(BMW.Id, "5系(进口)",  ValidityState.Enabled, CarSeriesGrade.MiddleLarge),
                new CarsBrandSeries(BMW.Id, "7系(进口)", ValidityState.Enabled, CarSeriesGrade.Large),
                new CarsBrandSeries(BMW.Id, "2系(进口)",  ValidityState.Enabled, CarSeriesGrade.MPV),

                new CarsBrandSeries(Benz.Id,"SLC级(进口)",ValidityState.Enabled,CarSeriesGrade.SportsCar),
                new CarsBrandSeries(Benz.Id, "V级", ValidityState.Enabled, CarSeriesGrade.MPV),
                new CarsBrandSeries(Benz.Id, "GLA", ValidityState.Enabled, CarSeriesGrade.SUV),
                new CarsBrandSeries(Benz.Id, "GLC",  ValidityState.Enabled, CarSeriesGrade.SUV),
                new CarsBrandSeries(Benz.Id, "E级",  ValidityState.Enabled, CarSeriesGrade.MiddleLarge),
                new CarsBrandSeries(Benz.Id, "E级(进口)",  ValidityState.Enabled, CarSeriesGrade.MiddleLarge),
                new CarsBrandSeries(Benz.Id, "S级(进口)",  ValidityState.Enabled, CarSeriesGrade.Large),
                new CarsBrandSeries(Benz.Id, "R级(进口)",  ValidityState.Enabled, CarSeriesGrade.MPV),
            };
                    db.InsertAll<CarsBrandSeries>(cbs);
                    db.InsertAll<CarsBrandSeries>(BrandSeries);
                    return cbs.Count + BrandSeries.Count;
                }

            }
            return 0;
        }
    }
}
