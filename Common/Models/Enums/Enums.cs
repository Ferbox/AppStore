namespace identity1.Common.Models.Enums
{
    public class Enums
    {
        public enum SizeBodyWatch
        {
            _38mm = 1,
            _42mm = 2
        }
        public enum MemberSize
        {
            _16gb = 1,
            _32gb = 2,
            _64gb = 3,
            _128gb = 4,
            _256gb = 5,
            _512gb = 6
        }
        public enum Color
        {
            red = 1,
            spacegray = 2,
            silver = 3,
            rose = 4,
            rosegold = 5,
            gold = 6
        }
        public enum TypeProduct
        {
            phone = 1,
            laptop = 2,
            tablet = 3,
            monoblock = 4,
            watch = 5,
            accessories = 6
        }
        public enum Displays
        {
            ipad = 1,
            ipadPro_10 = 2,
            ipadPro_13 = 3,
            imac_21 = 4,
            imac_27 = 5,
            macbook = 6,
            macAirOrPro = 7,
            macPro = 8,
            iphoneX = 9,
            iphone6s78 = 10,
            iphone6s78Plus = 11,
            iphoneSE = 12

        }
        public enum Status
        {
            processing = 1,
            ordering = 2,
            inTransit = 3,
            delivered = 4,
            completed = 5,
            canceled = 6
        }
        public enum Charakteristik
        {
            type = 1,
            member = 2,
            color = 3,
            display = 4,
            sizebody = 5,
            cellular = 6,
            touchbar = 7
        }
    }
}