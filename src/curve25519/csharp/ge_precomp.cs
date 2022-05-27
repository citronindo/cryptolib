﻿/** 
 * Copyright (C) 2015 langboost
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


namespace citronindo.crypto.curve25519
{

    public class Ge_precomp
    {

        public int[] yplusx;
        public int[] yminusx;
        public int[] xy2d;

        public Ge_precomp()
        {
            yplusx = new int[10];
            yminusx = new int[10];
            xy2d = new int[10];
        }

        public Ge_precomp(int[] new_yplusx, int[] new_yminusx,
                          int[] new_xy2d)
        {
            yplusx = new_yplusx;
            yminusx = new_yminusx;
            xy2d = new_xy2d;
        }
    }

}
