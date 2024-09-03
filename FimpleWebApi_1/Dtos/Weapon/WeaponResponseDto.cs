using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FimpleWebApi_1.Dtos.Weapon
{
    public class WeaponResponseDto
    {
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; }
    }
}