﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopDownShooter.Source.Gameplay.World.Interfaces;

namespace TopDownShooter.Source.Gameplay.World.Factories
{
    public class VerticalRouteFactory : IEnemyRouteFactory
    {
        public Route CreateRoute(Vector2 startPosition, float screenWidth, float screenHeight, int routeSteps)
        {
            return Route.CreateVerticalRoute(startPosition, screenHeight, routeSteps);
        }
    }
}