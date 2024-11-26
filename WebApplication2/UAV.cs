using System;

namespace WebApplication2
{
    public class UAV
    {
        public int Id { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Speed { get; set; }
        public string MissionType { get; set; }  // Ví dụ: "Rescue", "Surveillance"

        public UAV(int id, double x, double y, double z, double speed, string missionType)
        {
            Id = id;
            X = x;
            Y = y;
            Z = z;
            Speed = speed;
            MissionType = missionType;
        }

        // Phương thức cập nhật vị trí UAV
        public void UpdatePosition(double deltaX, double deltaY, double deltaZ)
        {
            X += deltaX;
            Y += deltaY;
            Z += deltaZ;
        }

        // Phương thức kiểm tra tính hợp lệ
        public bool IsValid()
        {
            return Speed > 0 && !string.IsNullOrWhiteSpace(MissionType);
        }
    }
}
