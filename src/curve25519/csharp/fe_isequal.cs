﻿/** 
 * Copyright (C) 2016 golf1052
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

namespace citronindo.cryptolib.curve25519.csharp
{
    public class Fe_isequal
    {
        /*
         * return 1 if f == g
         * return 0 if f != g
         */

        public static int fe_isequal(int[] f, int[] g)
        {
            int[] h = new int[10];
            Fe_sub.fe_sub(h, f, g);
            return 1 ^ (1 & (Fe_isnonzero.fe_isnonzero(h) >> 8));
        }
    }
}
