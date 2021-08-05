using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMoto.Data.Model
{
    public class Moto
    {
        public int id { set; get; }
        public string name { set; get; }
        public string shortDesc { set; get; }
        public string longDesc { set; get; }
        public string img { set; get; }
        public string imgInfo { set; get; }
        public string imgCountry { set; get; }
        public ushort price { set; get; }
        public bool isFavourite { set; get; }
        public bool available { set; get; }
        public int categoryID { set; get; }
        public virtual Category Category { set; get; }
        public string country { set; get; }
        public int volume { set; get; }
        public int number_cylinders { get; set; }
        public string arrangement_cylinders { get; set; }
        public string cooling { get; set; }
        public int number_measures { get; set; }
        public int valves { get; set; }
        public int cylinder_diameter { get; set; }
        public int piston_stroke { get; set; }
        public int power { set; get; }
        public int torque { set; get; }
        public int compression { get; set; }
        public string mixing_type { get; set; }
        public string launch_system { get; set; }
        public string clutch { get; set; }
        public string generator { get; set; }
        public int gear { set; get; }
        public string frame { set; get; }
        public string drive { set; get; }
        public string front_wheel_suspension { set; get; }
        public string rear_wheel_suspension { get; set; }
        public int rear_suspension_travel { get; set; }
        public int front_suspension_travel { get; set; }
        public int front_fork_stem { get; set; }
        public int fork_tilt_angle { get; set; }
        public int front_disk_dimension { get; set; }
        public int rear_disk_dimension { get; set; }
        public bool abs { get; set; }
        public bool traction_control { get; set; }
        public int length { get; set; }
        public int wheelbase { get; set; }
        public int width { get; set; }
        public int height_overall { get; set; }
        public int height_seaddle { get; set; }
        public int weight { get; set; }
        public int ground_clearance { get; set; }
        public int maximum_load { get; set; }
        public int fuel_tank_volume { get; set; }
        public int speed { get; set; }
        public int fuel_consumption { get; set; }
        public bool сenter_stand { get; set; }
        public bool heated_handles { get; set; }
        public bool heated_seat { get; set; }
        public bool saddle_adjustment { get; set; }
        public bool windscreen_adjustment { get; set; }
        public bool side_trunks { get; set; }
        public bool central_wardrobe_trunk { get; set; }
        public bool cruise_control { get; set; }
        public bool tire_pressure_sensor { get; set; }
        public bool steering_damper { get; set; }
        public bool engine_adjustment { get; set; }
        public bool suspension_adjustment { get; set; }
        public bool gear_shift_assistant { get; set; }
        public bool signaling { get; set; }
        public bool engine_protection { get; set; }
        public bool hand_protection { get; set; }
        public bool immobilizer { get; set; }
        public bool keyless_start { get; set; }
        public bool slipping_clutch { get; set; }
        public bool smartphone_connection { get; set; }
        public bool electronic_throttle { get; set; }
        public bool led_optics { get; set; }
        public bool color_display { get; set; }

    }
}
