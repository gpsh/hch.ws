using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.definition
{
    /// <summary>
    /// 车辆详情
    /// </summary>
    public interface ICarsDetails :IWxSuperModel
    {

        string Appearance { get; set; }

        string Interior { get; set; }
        
        string CarConfig { get; set; }

        DateTime? CarLicenseTime { get; set; }


        DateTime? CarAge { get; set; }

        float Mileage { get; set; }

        float Emission { get; set; }

        string[] Images { get; set; }

        CarDrive CarDrive { get; set; }

        CarEnergy CarEnergy { get; set; }

        CarGearbox CarGearbox { get; set; }

        CarSeat CarSeat { get; set; }

        CarEmissionStandard CarEmissionStandard { get; set; }
    }
}
