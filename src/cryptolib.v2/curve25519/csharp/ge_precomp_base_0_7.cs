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

namespace citronindo.cryptolib.curve25519.csharp
{

    public class Ge_precomp_base_0_7
    {
        /* base[i,j] = (j+1)*256^i*B */
        public static Ge_precomp[,] gepc_base;

        static Ge_precomp_base_0_7()
        {
            //CONVERT #include "base.h"
            gepc_base = new Ge_precomp[32, 8];

            gepc_base[0, 0] = new Ge_precomp(
        new int[] { 25967493, -14356035, 29566456, 3660896, -12694345, 4014787, 27544626, -11754271, -6079156, 2047605 },
        new int[] { -12545711, 934262, -2722910, 3049990, -727428, 9406986, 12720692, 5043384, 19500929, -15469378 },
        new int[] { -8738181, 4489570, 9688441, -14785194, 10184609, -12363380, 29287919, 11864899, -24514362, -4438546 }
    );
            gepc_base[0, 1] = new Ge_precomp(
        new int[] { -12815894, -12976347, -21581243, 11784320, -25355658, -2750717, -11717903, -3814571, -358445, -10211303 },
        new int[] { -21703237, 6903825, 27185491, 6451973, -29577724, -9554005, -15616551, 11189268, -26829678, -5319081 },
        new int[] { 26966642, 11152617, 32442495, 15396054, 14353839, -12752335, -3128826, -9541118, -15472047, -4166697 }
    );
            gepc_base[0, 2] = new Ge_precomp(
        new int[] { 15636291, -9688557, 24204773, -7912398, 616977, -16685262, 27787600, -14772189, 28944400, -1550024 },
        new int[] { 16568933, 4717097, -11556148, -1102322, 15682896, -11807043, 16354577, -11775962, 7689662, 11199574 },
        new int[] { 30464156, -5976125, -11779434, -15670865, 23220365, 15915852, 7512774, 10017326, -17749093, -9920357 }
    );
            gepc_base[0, 3] = new Ge_precomp(
        new int[] { -17036878, 13921892, 10945806, -6033431, 27105052, -16084379, -28926210, 15006023, 3284568, -6276540 },
        new int[] { 23599295, -8306047, -11193664, -7687416, 13236774, 10506355, 7464579, 9656445, 13059162, 10374397 },
        new int[] { 7798556, 16710257, 3033922, 2874086, 28997861, 2835604, 32406664, -3839045, -641708, -101325 }
    );
            gepc_base[0, 4] = new Ge_precomp(
                new int[] { 10861363, 11473154, 27284546, 1981175, -30064349, 12577861, 32867885, 14515107, -15438304, 10819380 },
                new int[] { 4708026, 6336745, 20377586, 9066809, -11272109, 6594696, -25653668, 12483688, -12668491, 5581306 },
                new int[] { 19563160, 16186464, -29386857, 4097519, 10237984, -4348115, 28542350, 13850243, -23678021, -15815942 }
            );
            gepc_base[0, 5] = new Ge_precomp(
                new int[] { -15371964, -12862754, 32573250, 4720197, -26436522, 5875511, -19188627, -15224819, -9818940, -12085777 },
                new int[] { -8549212, 109983, 15149363, 2178705, 22900618, 4543417, 3044240, -15689887, 1762328, 14866737 },
                new int[] { -18199695, -15951423, -10473290, 1707278, -17185920, 3916101, -28236412, 3959421, 27914454, 4383652 }
            );
            gepc_base[0, 6] = new Ge_precomp(
                new int[] { 5153746, 9909285, 1723747, -2777874, 30523605, 5516873, 19480852, 5230134, -23952439, -15175766 },
                new int[] { -30269007, -3463509, 7665486, 10083793, 28475525, 1649722, 20654025, 16520125, 30598449, 7715701 },
                new int[] { 28881845, 14381568, 9657904, 3680757, -20181635, 7843316, -31400660, 1370708, 29794553, -1409300 }
            );
            gepc_base[0, 7] = new Ge_precomp(
                new int[] { 14499471, -2729599, -33191113, -4254652, 28494862, 14271267, 30290735, 10876454, -33154098, 2381726 },
                new int[] { -7195431, -2655363, -14730155, 462251, -27724326, 3941372, -6236617, 3696005, -32300832, 15351955 },
                new int[] { 27431194, 8222322, 16448760, -3907995, -18707002, 11938355, -32961401, -2970515, 29551813, 10109425 }
            );
            gepc_base[1, 0] = new Ge_precomp(
                new int[] { -13657040, -13155431, -31283750, 11777098, 21447386, 6519384, -2378284, -1627556, 10092783, -4764171 },
                new int[] { 27939166, 14210322, 4677035, 16277044, -22964462, -12398139, -32508754, 12005538, -17810127, 12803510 },
                new int[] { 17228999, -15661624, -1233527, 300140, -1224870, -11714777, 30364213, -9038194, 18016357, 4397660 }
            );
            gepc_base[1, 1] = new Ge_precomp(
                new int[] { -10958843, -7690207, 4776341, -14954238, 27850028, -15602212, -26619106, 14544525, -17477504, 982639 },
                new int[] { 29253598, 15796703, -2863982, -9908884, 10057023, 3163536, 7332899, -4120128, -21047696, 9934963 },
                new int[] { 5793303, 16271923, -24131614, -10116404, 29188560, 1206517, -14747930, 4559895, -30123922, -10897950 }
            );
            gepc_base[1, 2] = new Ge_precomp(
                new int[] { -27643952, -11493006, 16282657, -11036493, 28414021, -15012264, 24191034, 4541697, -13338309, 5500568 },
                new int[] { 12650548, -1497113, 9052871, 11355358, -17680037, -8400164, -17430592, 12264343, 10874051, 13524335 },
                new int[] { 25556948, -3045990, 714651, 2510400, 23394682, -10415330, 33119038, 5080568, -22528059, 5376628 }
            );
            gepc_base[1, 3] = new Ge_precomp(
                new int[] { -26088264, -4011052, -17013699, -3537628, -6726793, 1920897, -22321305, -9447443, 4535768, 1569007 },
                new int[] { -2255422, 14606630, -21692440, -8039818, 28430649, 8775819, -30494562, 3044290, 31848280, 12543772 },
                new int[] { -22028579, 2943893, -31857513, 6777306, 13784462, -4292203, -27377195, -2062731, 7718482, 14474653 }
            );
            gepc_base[1, 4] = new Ge_precomp(
                new int[] { 2385315, 2454213, -22631320, 46603, -4437935, -15680415, 656965, -7236665, 24316168, -5253567 },
                new int[] { 13741529, 10911568, -33233417, -8603737, -20177830, -1033297, 33040651, -13424532, -20729456, 8321686 },
                new int[] { 21060490, -2212744, 15712757, -4336099, 1639040, 10656336, 23845965, -11874838, -9984458, 608372 }
            );
            gepc_base[1, 5] = new Ge_precomp(
                new int[] { -13672732, -15087586, -10889693, -7557059, -6036909, 11305547, 1123968, -6780577, 27229399, 23887 },
                new int[] { -23244140, -294205, -11744728, 14712571, -29465699, -2029617, 12797024, -6440308, -1633405, 16678954 },
                new int[] { -29500620, 4770662, -16054387, 14001338, 7830047, 9564805, -1508144, -4795045, -17169265, 4904953 }
            );
            gepc_base[1, 6] = new Ge_precomp(
                new int[] { 24059557, 14617003, 19037157, -15039908, 19766093, -14906429, 5169211, 16191880, 2128236, -4326833 },
                new int[] { -16981152, 4124966, -8540610, -10653797, 30336522, -14105247, -29806336, 916033, -6882542, -2986532 },
                new int[] { -22630907, 12419372, -7134229, -7473371, -16478904, 16739175, 285431, 2763829, 15736322, 4143876 }
            );
            gepc_base[1, 7] = new Ge_precomp(
                new int[] { 2379352, 11839345, -4110402, -5988665, 11274298, 794957, 212801, -14594663, 23527084, -16458268 },
                new int[] { 33431127, -11130478, -17838966, -15626900, 8909499, 8376530, -32625340, 4087881, -15188911, -14416214 },
                new int[] { 1767683, 7197987, -13205226, -2022635, -13091350, 448826, 5799055, 4357868, -4774191, -16323038 }
            );
            gepc_base[2, 0] = new Ge_precomp(
                new int[] { 6721966, 13833823, -23523388, -1551314, 26354293, -11863321, 23365147, -3949732, 7390890, 2759800 },
                new int[] { 4409041, 2052381, 23373853, 10530217, 7676779, -12885954, 21302353, -4264057, 1244380, -12919645 },
                new int[] { -4421239, 7169619, 4982368, -2957590, 30256825, -2777540, 14086413, 9208236, 15886429, 16489664 }
            );
            gepc_base[2, 1] = new Ge_precomp(
                new int[] { 1996075, 10375649, 14346367, 13311202, -6874135, -16438411, -13693198, 398369, -30606455, -712933 },
                new int[] { -25307465, 9795880, -2777414, 14878809, -33531835, 14780363, 13348553, 12076947, -30836462, 5113182 },
                new int[] { -17770784, 11797796, 31950843, 13929123, -25888302, 12288344, -30341101, -7336386, 13847711, 5387222 }
            );
            gepc_base[2, 2] = new Ge_precomp(
                new int[] { -18582163, -3416217, 17824843, -2340966, 22744343, -10442611, 8763061, 3617786, -19600662, 10370991 },
                new int[] { 20246567, -14369378, 22358229, -543712, 18507283, -10413996, 14554437, -8746092, 32232924, 16763880 },
                new int[] { 9648505, 10094563, 26416693, 14745928, -30374318, -6472621, 11094161, 15689506, 3140038, -16510092 }
            );
            gepc_base[2, 3] = new Ge_precomp(
                new int[] { -16160072, 5472695, 31895588, 4744994, 8823515, 10365685, -27224800, 9448613, -28774454, 366295 },
                new int[] { 19153450, 11523972, -11096490, -6503142, -24647631, 5420647, 28344573, 8041113, 719605, 11671788 },
                new int[] { 8678025, 2694440, -6808014, 2517372, 4964326, 11152271, -15432916, -15266516, 27000813, -10195553 }
            );
            gepc_base[2, 4] = new Ge_precomp(
                new int[] { -15157904, 7134312, 8639287, -2814877, -7235688, 10421742, 564065, 5336097, 6750977, -14521026 },
                new int[] { 11836410, -3979488, 26297894, 16080799, 23455045, 15735944, 1695823, -8819122, 8169720, 16220347 },
                new int[] { -18115838, 8653647, 17578566, -6092619, -8025777, -16012763, -11144307, -2627664, -5990708, -14166033 }
            );
            gepc_base[2, 5] = new Ge_precomp(
                new int[] { -23308498, -10968312, 15213228, -10081214, -30853605, -11050004, 27884329, 2847284, 2655861, 1738395 },
                new int[] { -27537433, -14253021, -25336301, -8002780, -9370762, 8129821, 21651608, -3239336, -19087449, -11005278 },
                new int[] { 1533110, 3437855, 23735889, 459276, 29970501, 11335377, 26030092, 5821408, 10478196, 8544890 }
            );
            gepc_base[2, 6] = new Ge_precomp(
                new int[] { 32173121, -16129311, 24896207, 3921497, 22579056, -3410854, 19270449, 12217473, 17789017, -3395995 },
                new int[] { -30552961, -2228401, -15578829, -10147201, 13243889, 517024, 15479401, -3853233, 30460520, 1052596 },
                new int[] { -11614875, 13323618, 32618793, 8175907, -15230173, 12596687, 27491595, -4612359, 3179268, -9478891 }
            );
            gepc_base[2, 7] = new Ge_precomp(
                new int[] { 31947069, -14366651, -4640583, -15339921, -15125977, -6039709, -14756777, -16411740, 19072640, -9511060 },
                new int[] { 11685058, 11822410, 3158003, -13952594, 33402194, -4165066, 5977896, -5215017, 473099, 5040608 },
                new int[] { -20290863, 8198642, -27410132, 11602123, 1290375, -2799760, 28326862, 1721092, -19558642, -3131606 }
            );
            gepc_base[3, 0] = new Ge_precomp(
                new int[] { 7881532, 10687937, 7578723, 7738378, -18951012, -2553952, 21820786, 8076149, -27868496, 11538389 },
                new int[] { -19935666, 3899861, 18283497, -6801568, -15728660, -11249211, 8754525, 7446702, -5676054, 5797016 },
                new int[] { -11295600, -3793569, -15782110, -7964573, 12708869, -8456199, 2014099, -9050574, -2369172, -5877341 }
            );
            gepc_base[3, 1] = new Ge_precomp(
                new int[] { -22472376, -11568741, -27682020, 1146375, 18956691, 16640559, 1192730, -3714199, 15123619, 10811505 },
                new int[] { 14352098, -3419715, -18942044, 10822655, 32750596, 4699007, -70363, 15776356, -28886779, -11974553 },
                new int[] { -28241164, -8072475, -4978962, -5315317, 29416931, 1847569, -20654173, -16484855, 4714547, -9600655 }
            );
            gepc_base[3, 2] = new Ge_precomp(
                new int[] { 15200332, 8368572, 19679101, 15970074, -31872674, 1959451, 24611599, -4543832, -11745876, 12340220 },
                new int[] { 12876937, -10480056, 33134381, 6590940, -6307776, 14872440, 9613953, 8241152, 15370987, 9608631 },
                new int[] { -4143277, -12014408, 8446281, -391603, 4407738, 13629032, -7724868, 15866074, -28210621, -8814099 }
            );
            gepc_base[3, 3] = new Ge_precomp(
                new int[] { 26660628, -15677655, 8393734, 358047, -7401291, 992988, -23904233, 858697, 20571223, 8420556 },
                new int[] { 14620715, 13067227, -15447274, 8264467, 14106269, 15080814, 33531827, 12516406, -21574435, -12476749 },
                new int[] { 236881, 10476226, 57258, -14677024, 6472998, 2466984, 17258519, 7256740, 8791136, 15069930 }
            );
            gepc_base[3, 4] = new Ge_precomp(
                new int[] { 1276410, -9371918, 22949635, -16322807, -23493039, -5702186, 14711875, 4874229, -30663140, -2331391 },
                new int[] { 5855666, 4990204, -13711848, 7294284, -7804282, 1924647, -1423175, -7912378, -33069337, 9234253 },
                new int[] { 20590503, -9018988, 31529744, -7352666, -2706834, 10650548, 31559055, -11609587, 18979186, 13396066 }
            );
            gepc_base[3, 5] = new Ge_precomp(
                new int[] { 24474287, 4968103, 22267082, 4407354, 24063882, -8325180, -18816887, 13594782, 33514650, 7021958 },
                new int[] { -11566906, -6565505, -21365085, 15928892, -26158305, 4315421, -25948728, -3916677, -21480480, 12868082 },
                new int[] { -28635013, 13504661, 19988037, -2132761, 21078225, 6443208, -21446107, 2244500, -12455797, -8089383 }
            );
            gepc_base[3, 6] = new Ge_precomp(
                new int[] { -30595528, 13793479, -5852820, 319136, -25723172, -6263899, 33086546, 8957937, -15233648, 5540521 },
                new int[] { -11630176, -11503902, -8119500, -7643073, 2620056, 1022908, -23710744, -1568984, -16128528, -14962807 },
                new int[] { 23152971, 775386, 27395463, 14006635, -9701118, 4649512, 1689819, 892185, -11513277, -15205948 }
            );
            gepc_base[3, 7] = new Ge_precomp(
                new int[] { 9770129, 9586738, 26496094, 4324120, 1556511, -3550024, 27453819, 4763127, -19179614, 5867134 },
                new int[] { -32765025, 1927590, 31726409, -4753295, 23962434, -16019500, 27846559, 5931263, -29749703, -16108455 },
                new int[] { 27461885, -2977536, 22380810, 1815854, -23033753, -3031938, 7283490, -15148073, -19526700, 7734629 }
            );
            gepc_base[4, 0] = new Ge_precomp(
                new int[] { -8010264, -9590817, -11120403, 6196038, 29344158, -13430885, 7585295, -3176626, 18549497, 15302069 },
                new int[] { -32658337, -6171222, -7672793, -11051681, 6258878, 13504381, 10458790, -6418461, -8872242, 8424746 },
                new int[] { 24687205, 8613276, -30667046, -3233545, 1863892, -1830544, 19206234, 7134917, -11284482, -828919 }
            );
            gepc_base[4, 1] = new Ge_precomp(
                new int[] { 11334899, -9218022, 8025293, 12707519, 17523892, -10476071, 10243738, -14685461, -5066034, 16498837 },
                new int[] { 8911542, 6887158, -9584260, -6958590, 11145641, -9543680, 17303925, -14124238, 6536641, 10543906 },
                new int[] { -28946384, 15479763, -17466835, 568876, -1497683, 11223454, -2669190, -16625574, -27235709, 8876771 }
            );
            gepc_base[4, 2] = new Ge_precomp(
                new int[] { -25742899, -12566864, -15649966, -846607, -33026686, -796288, -33481822, 15824474, -604426, -9039817 },
                new int[] { 10330056, 70051, 7957388, -9002667, 9764902, 15609756, 27698697, -4890037, 1657394, 3084098 },
                new int[] { 10477963, -7470260, 12119566, -13250805, 29016247, -5365589, 31280319, 14396151, -30233575, 15272409 }
            );
            gepc_base[4, 3] = new Ge_precomp(
                new int[] { -12288309, 3169463, 28813183, 16658753, 25116432, -5630466, -25173957, -12636138, -25014757, 1950504 },
                new int[] { -26180358, 9489187, 11053416, -14746161, -31053720, 5825630, -8384306, -8767532, 15341279, 8373727 },
                new int[] { 28685821, 7759505, -14378516, -12002860, -31971820, 4079242, 298136, -10232602, -2878207, 15190420 }
            );
            gepc_base[4, 4] = new Ge_precomp(
                new int[] { -32932876, 13806336, -14337485, -15794431, -24004620, 10940928, 8669718, 2742393, -26033313, -6875003 },
                new int[] { -1580388, -11729417, -25979658, -11445023, -17411874, -10912854, 9291594, -16247779, -12154742, 6048605 },
                new int[] { -30305315, 14843444, 1539301, 11864366, 20201677, 1900163, 13934231, 5128323, 11213262, 9168384 }
            );
            gepc_base[4, 5] = new Ge_precomp(
                new int[] { -26280513, 11007847, 19408960, -940758, -18592965, -4328580, -5088060, -11105150, 20470157, -16398701 },
                new int[] { -23136053, 9282192, 14855179, -15390078, -7362815, -14408560, -22783952, 14461608, 14042978, 5230683 },
                new int[] { 29969567, -2741594, -16711867, -8552442, 9175486, -2468974, 21556951, 3506042, -5933891, -12449708 }
            );
            gepc_base[4, 6] = new Ge_precomp(
                new int[] { -3144746, 8744661, 19704003, 4581278, -20430686, 6830683, -21284170, 8971513, -28539189, 15326563 },
                new int[] { -19464629, 10110288, -17262528, -3503892, -23500387, 1355669, -15523050, 15300988, -20514118, 9168260 },
                new int[] { -5353335, 4488613, -23803248, 16314347, 7780487, -15638939, -28948358, 9601605, 33087103, -9011387 }
            );
            gepc_base[4, 7] = new Ge_precomp(
                new int[] { -19443170, -15512900, -20797467, -12445323, -29824447, 10229461, -27444329, -15000531, -5996870, 15664672 },
                new int[] { 23294591, -16632613, -22650781, -8470978, 27844204, 11461195, 13099750, -2460356, 18151676, 13417686 },
                new int[] { -24722913, -4176517, -31150679, 5988919, -26858785, 6685065, 1661597, -12551441, 15271676, -15452665 }
            );
            gepc_base[5, 0] = new Ge_precomp(
                new int[] { 11433042, -13228665, 8239631, -5279517, -1985436, -725718, -18698764, 2167544, -6921301, -13440182 },
                new int[] { -31436171, 15575146, 30436815, 12192228, -22463353, 9395379, -9917708, -8638997, 12215110, 12028277 },
                new int[] { 14098400, 6555944, 23007258, 5757252, -15427832, -12950502, 30123440, 4617780, -16900089, -655628 }
            );
            gepc_base[5, 1] = new Ge_precomp(
                new int[] { -4026201, -15240835, 11893168, 13718664, -14809462, 1847385, -15819999, 10154009, 23973261, -12684474 },
                new int[] { -26531820, -3695990, -1908898, 2534301, -31870557, -16550355, 18341390, -11419951, 32013174, -10103539 },
                new int[] { -25479301, 10876443, -11771086, -14625140, -12369567, 1838104, 21911214, 6354752, 4425632, -837822 }
            );
            gepc_base[5, 2] = new Ge_precomp(
                new int[] { -10433389, -14612966, 22229858, -3091047, -13191166, 776729, -17415375, -12020462, 4725005, 14044970 },
                new int[] { 19268650, -7304421, 1555349, 8692754, -21474059, -9910664, 6347390, -1411784, -19522291, -16109756 },
                new int[] { -24864089, 12986008, -10898878, -5558584, -11312371, -148526, 19541418, 8180106, 9282262, 10282508 }
            );
            gepc_base[5, 3] = new Ge_precomp(
                new int[] { -26205082, 4428547, -8661196, -13194263, 4098402, -14165257, 15522535, 8372215, 5542595, -10702683 },
                new int[] { -10562541, 14895633, 26814552, -16673850, -17480754, -2489360, -2781891, 6993761, -18093885, 10114655 },
                new int[] { -20107055, -929418, 31422704, 10427861, -7110749, 6150669, -29091755, -11529146, 25953725, -106158 }
            );
            gepc_base[5, 4] = new Ge_precomp(
                new int[] { -4234397, -8039292, -9119125, 3046000, 2101609, -12607294, 19390020, 6094296, -3315279, 12831125 },
                new int[] { -15998678, 7578152, 5310217, 14408357, -33548620, -224739, 31575954, 6326196, 7381791, -2421839 },
                new int[] { -20902779, 3296811, 24736065, -16328389, 18374254, 7318640, 6295303, 8082724, -15362489, 12339664 }
            );
            gepc_base[5, 5] = new Ge_precomp(
                new int[] { 27724736, 2291157, 6088201, -14184798, 1792727, 5857634, 13848414, 15768922, 25091167, 14856294 },
                new int[] { -18866652, 8331043, 24373479, 8541013, -701998, -9269457, 12927300, -12695493, -22182473, -9012899 },
                new int[] { -11423429, -5421590, 11632845, 3405020, 30536730, -11674039, -27260765, 13866390, 30146206, 9142070 }
            );
            gepc_base[5, 6] = new Ge_precomp(
                new int[] { 3924129, -15307516, -13817122, -10054960, 12291820, -668366, -27702774, 9326384, -8237858, 4171294 },
                new int[] { -15921940, 16037937, 6713787, 16606682, -21612135, 2790944, 26396185, 3731949, 345228, -5462949 },
                new int[] { -21327538, 13448259, 25284571, 1143661, 20614966, -8849387, 2031539, -12391231, -16253183, -13582083 }
            );
            gepc_base[5, 7] = new Ge_precomp(
                new int[] { 31016211, -16722429, 26371392, -14451233, -5027349, 14854137, 17477601, 3842657, 28012650, -16405420 },
                new int[] { -5075835, 9368966, -8562079, -4600902, -15249953, 6970560, -9189873, 16292057, -8867157, 3507940 },
                new int[] { 29439664, 3537914, 23333589, 6997794, -17555561, -11018068, -15209202, -15051267, -9164929, 6580396 }
            );
            gepc_base[6, 0] = new Ge_precomp(
                new int[] { -12185861, -7679788, 16438269, 10826160, -8696817, -6235611, 17860444, -9273846, -2095802, 9304567 },
                new int[] { 20714564, -4336911, 29088195, 7406487, 11426967, -5095705, 14792667, -14608617, 5289421, -477127 },
                new int[] { -16665533, -10650790, -6160345, -13305760, 9192020, -1802462, 17271490, 12349094, 26939669, -3752294 }
            );
            gepc_base[6, 1] = new Ge_precomp(
                new int[] { -12889898, 9373458, 31595848, 16374215, 21471720, 13221525, -27283495, -12348559, -3698806, 117887 },
                new int[] { 22263325, -6560050, 3984570, -11174646, -15114008, -566785, 28311253, 5358056, -23319780, 541964 },
                new int[] { 16259219, 3261970, 2309254, -15534474, -16885711, -4581916, 24134070, -16705829, -13337066, -13552195 }
            );
            gepc_base[6, 2] = new Ge_precomp(
                new int[] { 9378160, -13140186, -22845982, -12745264, 28198281, -7244098, -2399684, -717351, 690426, 14876244 },
                new int[] { 24977353, -314384, -8223969, -13465086, 28432343, -1176353, -13068804, -12297348, -22380984, 6618999 },
                new int[] { -1538174, 11685646, 12944378, 13682314, -24389511, -14413193, 8044829, -13817328, 32239829, -5652762 }
            );
            gepc_base[6, 3] = new Ge_precomp(
                new int[] { -18603066, 4762990, -926250, 8885304, -28412480, -3187315, 9781647, -10350059, 32779359, 5095274 },
                new int[] { -33008130, -5214506, -32264887, -3685216, 9460461, -9327423, -24601656, 14506724, 21639561, -2630236 },
                new int[] { -16400943, -13112215, 25239338, 15531969, 3987758, -4499318, -1289502, -6863535, 17874574, 558605 }
            );
            gepc_base[6, 4] = new Ge_precomp(
                new int[] { -13600129, 10240081, 9171883, 16131053, -20869254, 9599700, 33499487, 5080151, 2085892, 5119761 },
                new int[] { -22205145, -2519528, -16381601, 414691, -25019550, 2170430, 30634760, -8363614, -31999993, -5759884 },
                new int[] { -6845704, 15791202, 8550074, -1312654, 29928809, -12092256, 27534430, -7192145, -22351378, 12961482 }
            );
            gepc_base[6, 5] = new Ge_precomp(
                new int[] { -24492060, -9570771, 10368194, 11582341, -23397293, -2245287, 16533930, 8206996, -30194652, -5159638 },
                new int[] { -11121496, -3382234, 2307366, 6362031, -135455, 8868177, -16835630, 7031275, 7589640, 8945490 },
                new int[] { -32152748, 8917967, 6661220, -11677616, -1192060, -15793393, 7251489, -11182180, 24099109, -14456170 }
            );
            gepc_base[6, 6] = new Ge_precomp(
                new int[] { 5019558, -7907470, 4244127, -14714356, -26933272, 6453165, -19118182, -13289025, -6231896, -10280736 },
                new int[] { 10853594, 10721687, 26480089, 5861829, -22995819, 1972175, -1866647, -10557898, -3363451, -6441124 },
                new int[] { -17002408, 5906790, 221599, -6563147, 7828208, -13248918, 24362661, -2008168, -13866408, 7421392 }
            );
            gepc_base[6, 7] = new Ge_precomp(
                new int[] { 8139927, -6546497, 32257646, -5890546, 30375719, 1886181, -21175108, 15441252, 28826358, -4123029 },
                new int[] { 6267086, 9695052, 7709135, -16603597, -32869068, -1886135, 14795160, -7840124, 13746021, -1742048 },
                new int[] { 28584902, 7787108, -6732942, -15050729, 22846041, -7571236, -3181936, -363524, 4771362, -8419958 }
            );
            gepc_base[7, 0] = new Ge_precomp(
                new int[] { 24949256, 6376279, -27466481, -8174608, -18646154, -9930606, 33543569, -12141695, 3569627, 11342593 },
                new int[] { 26514989, 4740088, 27912651, 3697550, 19331575, -11472339, 6809886, 4608608, 7325975, -14801071 },
                new int[] { -11618399, -14554430, -24321212, 7655128, -1369274, 5214312, -27400540, 10258390, -17646694, -8186692 }
            );
            gepc_base[7, 1] = new Ge_precomp(
                new int[] { 11431204, 15823007, 26570245, 14329124, 18029990, 4796082, -31446179, 15580664, 9280358, -3973687 },
                new int[] { -160783, -10326257, -22855316, -4304997, -20861367, -13621002, -32810901, -11181622, -15545091, 4387441 },
                new int[] { -20799378, 12194512, 3937617, -5805892, -27154820, 9340370, -24513992, 8548137, 20617071, -7482001 }
            );
            gepc_base[7, 2] = new Ge_precomp(
                new int[] { -938825, -3930586, -8714311, 16124718, 24603125, -6225393, -13775352, -11875822, 24345683, 10325460 },
                new int[] { -19855277, -1568885, -22202708, 8714034, 14007766, 6928528, 16318175, -1010689, 4766743, 3552007 },
                new int[] { -21751364, -16730916, 1351763, -803421, -4009670, 3950935, 3217514, 14481909, 10988822, -3994762 }
            );
            gepc_base[7, 3] = new Ge_precomp(
                new int[] { 15564307, -14311570, 3101243, 5684148, 30446780, -8051356, 12677127, -6505343, -8295852, 13296005 },
                new int[] { -9442290, 6624296, -30298964, -11913677, -4670981, -2057379, 31521204, 9614054, -30000824, 12074674 },
                new int[] { 4771191, -135239, 14290749, -13089852, 27992298, 14998318, -1413936, -1556716, 29832613, -16391035 }
            );
            gepc_base[7, 4] = new Ge_precomp(
                new int[] { 7064884, -7541174, -19161962, -5067537, -18891269, -2912736, 25825242, 5293297, -27122660, 13101590 },
                new int[] { -2298563, 2439670, -7466610, 1719965, -27267541, -16328445, 32512469, -5317593, -30356070, -4190957 },
                new int[] { -30006540, 10162316, -33180176, 3981723, -16482138, -13070044, 14413974, 9515896, 19568978, 9628812 }
            );
            gepc_base[7, 5] = new Ge_precomp(
                new int[] { 33053803, 199357, 15894591, 1583059, 27380243, -4580435, -17838894, -6106839, -6291786, 3437740 },
                new int[] { -18978877, 3884493, 19469877, 12726490, 15913552, 13614290, -22961733, 70104, 7463304, 4176122 },
                new int[] { -27124001, 10659917, 11482427, -16070381, 12771467, -6635117, -32719404, -5322751, 24216882, 5944158 }
            );
            gepc_base[7, 6] = new Ge_precomp(
                new int[] { 8894125, 7450974, -2664149, -9765752, -28080517, -12389115, 19345746, 14680796, 11632993, 5847885 },
                new int[] { 26942781, -2315317, 9129564, -4906607, 26024105, 11769399, -11518837, 6367194, -9727230, 4782140 },
                new int[] { 19916461, -4828410, -22910704, -11414391, 25606324, -5972441, 33253853, 8220911, 6358847, -1873857 }
            );
            gepc_base[7, 7] = new Ge_precomp(
                new int[] { 801428, -2081702, 16569428, 11065167, 29875704, 96627, 7908388, -4480480, -13538503, 1387155 },
                new int[] { 19646058, 5720633, -11416706, 12814209, 11607948, 12749789, 14147075, 15156355, -21866831, 11835260 },
                new int[] { 19299512, 1155910, 28703737, 14890794, 2925026, 7269399, 26121523, 15467869, -26560550, 5052483 }
            );
        }
    }
}
