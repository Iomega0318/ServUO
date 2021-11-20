
////////////////////////////////////////
//                                    //
//   Generated by CEO's YAAAG - V1.2  //
// (Yet Another Arya Addon Generator) //
//                                    //
////////////////////////////////////////
using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class RewardHouse2Addon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {1312, -7, -7, 0}, {1316, -7, -6, 0}, {1312, -6, -7, 0}// 1	2	3	
			, {1216, -6, -6, 0}, {1316, -5, -7, 0}, {1212, -5, -6, 0}// 4	5	6	
			, {1316, -4, -7, 0}, {1212, -4, -6, 0}, {1316, -3, -7, 0}// 7	8	9	
			, {1212, -3, -6, 0}, {1316, -2, -7, 0}, {1212, -2, -6, 0}// 10	11	12	
			, {1312, -1, -7, 0}, {1212, -1, -6, 0}, {1316, 0, -7, 0}// 13	14	15	
			, {1212, 0, -6, 0}, {1316, 1, -7, 0}, {1212, 1, -6, 0}// 16	17	18	
			, {1316, 2, -7, 0}, {1212, 2, -6, 0}, {1312, 3, -7, 0}// 19	20	21	
			, {1215, 3, -6, 0}, {1204, 4, -7, 0}, {1197, 4, -6, 0}// 22	23	24	
			, {1200, 5, -7, 0}, {1193, 5, -6, 0}, {1216, -6, -6, 20}// 25	26	27	
			, {1212, -5, -6, 20}, {1212, -4, -6, 20}, {1212, -3, -6, 20}// 28	29	30	
			, {1212, -2, -6, 20}, {1212, -1, -6, 20}, {1212, 0, -6, 20}// 31	32	33	
			, {1212, 1, -6, 20}, {1212, 2, -6, 20}, {1215, 3, -6, 20}// 34	35	36	
			, {50, -8, -7, 0}, {50, -8, -6, 0}, {49, -7, -8, 0}// 37	38	39	
			, {29, -7, -7, 0}, {43, -7, -6, 0}, {49, -6, -8, 0}// 40	41	42	
			, {44, -6, -7, 0}, {49, -5, -8, 0}, {49, -4, -8, 0}// 43	44	45	
			, {49, -3, -8, 0}, {49, -2, -8, 0}, {41, -2, -7, 0}// 46	47	48	
			, {49, -1, -8, 0}, {44, -1, -7, 0}, {49, 0, -8, 0}// 49	50	51	
			, {49, 1, -8, 0}, {49, 2, -8, 0}, {41, 2, -7, 0}// 52	53	54	
			, {29, 3, -8, 0}, {27, 3, -7, 0}, {27, 3, -6, 0}// 55	56	57	
			, {28, 4, -8, 0}, {28, 5, -8, 0}, {29, -7, -7, 20}// 58	59	60	
			, {27, -7, -6, 20}, {28, -6, -7, 20}, {28, -5, -7, 20}// 61	62	63	
			, {28, -4, -7, 20}, {28, -3, -7, 20}, {28, -2, -7, 20}// 64	65	66	
			, {28, -1, -7, 20}, {28, 0, -7, 20}, {28, 1, -7, 20}// 67	68	69	
			, {28, 2, -7, 20}, {28, 3, -7, 20}, {27, 3, -6, 20}// 70	71	72	
			, {10455, 3, -6, 40}, {10458, 2, -6, 40}, {10458, 1, -6, 40}// 73	74	75	
			, {10458, 0, -6, 40}, {10458, -1, -6, 40}, {10458, -2, -6, 40}// 76	77	78	
			, {10458, -3, -6, 40}, {10458, -4, -6, 40}, {10458, -5, -6, 40}// 79	80	81	
			, {10453, -6, -6, 40}, {10441, 4, -6, 37}, {10442, -7, -6, 37}// 82	83	84	
			, {10455, 4, -7, 37}, {10458, 3, -7, 37}, {10458, 2, -7, 37}// 85	86	87	
			, {10458, 1, -7, 37}, {10458, 0, -7, 37}, {10458, -1, -7, 37}// 88	89	90	
			, {10458, -2, -7, 37}, {10458, -3, -7, 37}, {10458, -4, -7, 37}// 91	92	93	
			, {10458, -5, -7, 37}, {10458, -6, -7, 37}, {10453, -7, -7, 37}// 94	95	96	
			, {10453, 5, -6, 20}, {10442, 4, -6, 17}, {10458, 5, -7, 17}// 97	98	99	
			, {10453, 4, -7, 17}, {1312, -7, -5, 0}, {1312, -7, -4, 0}// 100	101	102	
			, {1316, -7, -3, 0}, {1312, -7, -2, 0}, {1316, -7, -1, 0}// 103	104	105	
			, {1312, -7, 0, 0}, {1312, -7, 1, 0}, {1313, -7, 2, 0}// 106	107	108	
			, {1307, -7, 3, 0}, {1307, -7, 4, 0}, {1307, -7, 5, 0}// 109	110	111	
			, {1307, -7, 6, 0}, {1307, -7, 7, 0}, {1307, -7, 8, 0}// 112	113	114	
			, {1312, -7, 9, 0}, {1209, -6, -5, 0}, {1209, -6, -4, 0}// 115	116	117	
			, {1209, -6, -3, 0}, {1209, -6, -2, 0}, {1209, -6, -1, 0}// 118	119	120	
			, {1214, -6, 0, 0}, {1316, -6, 1, 0}, {1312, -6, 2, 0}// 121	122	123	
			, {1307, -6, 3, 0}, {1307, -6, 4, 0}, {1307, -6, 5, 0}// 124	125	126	
			, {1307, -6, 6, 0}, {1307, -6, 7, 0}, {1307, -6, 8, 0}// 127	128	129	
			, {1312, -6, 9, 0}, {1205, -5, -5, 0}, {1205, -5, -4, 0}// 130	131	132	
			, {1205, -5, -3, 0}, {1205, -5, -2, 0}, {1205, -5, -1, 0}// 133	134	135	
			, {1210, -5, 0, 0}, {1312, -5, 1, 0}, {1312, -5, 2, 0}// 136	137	138	
			, {1312, -5, 3, 0}, {1316, -5, 4, 0}, {1316, -5, 5, 0}// 139	140	141	
			, {1313, -5, 6, 0}, {1312, -5, 7, 0}, {1316, -5, 8, 0}// 142	143	144	
			, {1312, -5, 9, 0}, {1206, -4, -5, 0}, {1206, -4, -4, 0}// 145	146	147	
			, {1206, -4, -3, 0}, {1206, -4, -2, 0}, {1206, -4, -1, 0}// 148	149	150	
			, {1210, -4, 0, 0}, {1316, -4, 1, 0}, {1312, -4, 2, 0}// 151	152	153	
			, {1313, -4, 3, 0}, {1312, -4, 4, 0}, {1312, -4, 5, 0}// 154	155	156	
			, {1313, -4, 6, 0}, {1316, -4, 7, 0}, {1316, -4, 8, 0}// 157	158	159	
			, {1312, -4, 9, 0}, {1207, -3, -5, 0}, {1207, -3, -4, 0}// 160	161	162	
			, {1207, -3, -3, 0}, {1207, -3, -2, 0}, {1207, -3, -1, 0}// 163	164	165	
			, {1210, -3, 0, 0}, {1316, -3, 1, 0}, {1307, -3, 2, 0}// 166	167	168	
			, {1307, -3, 3, 0}, {1312, -3, 4, 0}, {1307, -3, 5, 0}// 169	170	171	
			, {1307, -3, 6, 0}, {1313, -3, 7, 0}, {1307, -3, 8, 0}// 172	173	174	
			, {1307, -3, 9, 0}, {1207, -2, -5, 0}, {1207, -2, -4, 0}// 175	176	177	
			, {1207, -2, -3, 0}, {1207, -2, -2, 0}, {1207, -2, -1, 0}// 178	179	180	
			, {1210, -2, 0, 0}, {1312, -2, 1, 0}, {1307, -2, 2, 0}// 181	182	183	
			, {1307, -2, 3, 0}, {1312, -2, 4, 0}, {1307, -2, 5, 0}// 184	185	186	
			, {1307, -2, 6, 0}, {1312, -2, 7, 0}, {1307, -2, 8, 0}// 187	188	189	
			, {1307, -2, 9, 0}, {1208, -1, -5, 0}, {1208, -1, -4, 0}// 190	191	192	
			, {1208, -1, -3, 0}, {1208, -1, -2, 0}, {1208, -1, -1, 0}// 193	194	195	
			, {1210, -1, 0, 0}, {1312, -1, 1, 0}, {1307, -1, 2, 0}// 196	197	198	
			, {1307, -1, 3, 0}, {1312, -1, 4, 0}, {1307, -1, 5, 0}// 199	200	201	
			, {1307, -1, 6, 0}, {1316, -1, 7, 0}, {1307, -1, 8, 0}// 202	203	204	
			, {1307, -1, 9, 0}, {1205, 0, -5, 0}, {1205, 0, -4, 0}// 205	206	207	
			, {1205, 0, -3, 0}, {1205, 0, -2, 0}, {1205, 0, -1, 0}// 208	209	210	
			, {1210, 0, 0, 0}, {1312, 0, 1, 0}, {1307, 0, 2, 0}// 211	212	213	
			, {1307, 0, 3, 0}, {1316, 0, 4, 0}, {1307, 0, 5, 0}// 214	215	216	
			, {1307, 0, 6, 0}, {1312, 0, 7, 0}, {1307, 0, 8, 0}// 217	218	219	
			, {1307, 0, 9, 0}, {1206, 1, -5, 0}, {1206, 1, -4, 0}// 220	221	222	
			, {1206, 1, -3, 0}, {1206, 1, -2, 0}, {1206, 1, -1, 0}// 223	224	225	
			, {1210, 1, 0, 0}, {1312, 1, 1, 0}, {1307, 1, 2, 0}// 226	227	228	
			, {1307, 1, 3, 0}, {1313, 1, 4, 0}, {1307, 1, 5, 0}// 229	230	231	
			, {1307, 1, 6, 0}, {1312, 1, 7, 0}, {1307, 1, 8, 0}// 232	233	234	
			, {1307, 1, 9, 0}, {1207, 2, -5, 0}, {1207, 2, -4, 0}// 235	236	237	
			, {1207, 2, -3, 0}, {1207, 2, -2, 0}, {1207, 2, -1, 0}// 238	239	240	
			, {1210, 2, 0, 0}, {1312, 2, 1, 0}, {1307, 2, 2, 0}// 241	242	243	
			, {1307, 2, 3, 0}, {1312, 2, 4, 0}, {1307, 2, 5, 0}// 244	245	246	
			, {1307, 2, 6, 0}, {1316, 2, 7, 0}, {1307, 2, 8, 0}// 247	248	249	
			, {1307, 2, 9, 0}, {1211, 3, -5, 0}, {1211, 3, -4, 0}// 250	251	252	
			, {1211, 3, -3, 0}, {1211, 3, -2, 0}, {1211, 3, -1, 0}// 253	254	255	
			, {1213, 3, 0, 0}, {1312, 3, 1, 0}, {1312, 3, 2, 0}// 256	257	258	
			, {1316, 3, 3, 0}, {1316, 3, 4, 0}, {1312, 3, 5, 0}// 259	260	261	
			, {1312, 3, 6, 0}, {1316, 3, 7, 0}, {1312, 3, 8, 0}// 262	263	264	
			, {1316, 3, 9, 0}, {1197, 4, -5, 0}, {1197, 4, -4, 0}// 265	266	267	
			, {1202, 4, -3, 0}, {1312, 4, -2, 0}, {1316, 4, -1, 0}// 268	269	270	
			, {1312, 4, 0, 0}, {1312, 4, 1, 0}, {1316, 4, 2, 0}// 271	272	273	
			, {1316, 4, 3, 0}, {1313, 4, 4, 0}, {1312, 4, 5, 0}// 274	275	276	
			, {1312, 4, 6, 0}, {1312, 4, 7, 0}, {1312, 4, 8, 0}// 277	278	279	
			, {1316, 4, 9, 0}, {1193, 5, -5, 0}, {1193, 5, -4, 0}// 280	281	282	
			, {1198, 5, -3, 0}, {1312, 5, -2, 0}, {1312, 5, -1, 0}// 283	284	285	
			, {1312, 5, 0, 0}, {1312, 5, 1, 0}, {1312, 5, 2, 0}// 286	287	288	
			, {1307, 5, 3, 0}, {1307, 5, 4, 0}, {1307, 5, 5, 0}// 289	290	291	
			, {1307, 5, 6, 0}, {1307, 5, 7, 0}, {1307, 5, 8, 0}// 292	293	294	
			, {1312, 5, 9, 0}, {1209, -6, -5, 20}, {1209, -6, -4, 20}// 295	296	297	
			, {1209, -6, -3, 20}, {1209, -6, -2, 20}, {1209, -6, -1, 20}// 298	299	300	
			, {1214, -6, 0, 20}, {1205, -5, -5, 20}, {1208, -5, -4, 20}// 301	302	303	
			, {1207, -5, -3, 20}, {1206, -5, -2, 20}, {1205, -5, -1, 20}// 304	305	306	
			, {1210, -5, 0, 20}, {1206, -4, -5, 20}, {1205, -4, -4, 20}// 307	308	309	
			, {1208, -4, -3, 20}, {1207, -4, -2, 20}, {1206, -4, -1, 20}// 310	311	312	
			, {1210, -4, 0, 20}, {1206, -3, -5, 20}, {1206, -3, -4, 20}// 313	314	315	
			, {1205, -3, -3, 20}, {1208, -3, -2, 20}, {1207, -3, -1, 20}// 316	317	318	
			, {1210, -3, 0, 20}, {1207, -2, -5, 20}, {1207, -2, -4, 20}// 319	320	321	
			, {1207, -2, -3, 20}, {1205, -2, -2, 20}, {1208, -2, -1, 20}// 322	323	324	
			, {1210, -2, 0, 20}, {1207, -1, -5, 20}, {1207, -1, -4, 20}// 325	326	327	
			, {1207, -1, -3, 20}, {1206, -1, -2, 20}, {1205, -1, -1, 20}// 328	329	330	
			, {1210, -1, 0, 20}, {1208, 0, -5, 20}, {1208, 0, -4, 20}// 331	332	333	
			, {1207, 0, -3, 20}, {1207, 0, -2, 20}, {1206, 0, -1, 20}// 334	335	336	
			, {1210, 0, 0, 20}, {1205, 1, -5, 20}, {1208, 1, -4, 20}// 337	338	339	
			, {1207, 1, -3, 20}, {1207, 1, -2, 20}, {1207, 1, -1, 20}// 340	341	342	
			, {1210, 1, 0, 20}, {1206, 2, -5, 20}, {1205, 2, -4, 20}// 343	344	345	
			, {1205, 2, -3, 20}, {1207, 2, -2, 20}, {1210, 2, 0, 20}// 346	347	348	
			, {1211, 3, -5, 20}, {1211, 3, -4, 20}, {1211, 3, -3, 20}// 349	350	351	
			, {1211, 3, -2, 20}, {1211, 3, -1, 20}, {1213, 3, 0, 20}// 352	353	354	
			, {50, -8, -5, 0}, {50, -8, -4, 0}, {50, -8, -3, 0}// 355	356	357	
			, {50, -8, -2, 0}, {50, -8, -1, 0}, {50, -8, 0, 0}// 358	359	360	
			, {50, -8, 1, 0}, {50, -8, 2, 0}, {50, -8, 3, 0}// 361	362	363	
			, {50, -8, 4, 0}, {50, -8, 5, 0}, {50, -8, 6, 0}// 364	365	366	
			, {50, -8, 7, 0}, {50, -8, 8, 0}, {50, -8, 9, 0}// 367	368	369	
			, {42, -7, -4, 0}, {43, -7, -3, 0}, {42, -7, 0, 0}// 370	371	372	
			, {44, -6, 0, 0}, {6429, -6, 3, 0}, {6428, -6, 4, 0}// 373	374	375	
			, {6428, -6, 5, 0}, {6428, -6, 6, 0}, {6428, -6, 7, 0}// 376	377	378	
			, {6428, -6, 8, 0}, {6431, -3, 3, 0}, {6431, -3, 6, 0}// 379	380	381	
			, {6431, -3, 9, 0}, {41, -2, 0, 0}, {6430, -2, 3, 0}// 382	383	384	
			, {6430, -2, 6, 0}, {6430, -2, 9, 0}, {44, -1, 0, 0}// 385	386	387	
			, {6430, -1, 3, 0}, {6430, -1, 6, 0}, {6430, -1, 9, 0}// 388	389	390	
			, {6430, 0, 3, 0}, {6430, 0, 6, 0}, {6430, 0, 9, 0}// 391	392	393	
			, {6430, 1, 3, 0}, {6430, 1, 6, 0}, {6430, 1, 9, 0}// 394	395	396	
			, {6430, 2, 3, 0}, {6430, 2, 6, 0}, {6430, 2, 9, 0}// 397	398	399	
			, {27, 3, -5, 0}, {27, 3, -4, 0}, {27, 3, -3, 0}// 400	401	402	
			, {40, 3, 0, 0}, {28, 4, -3, 0}, {28, 5, -3, 0}// 403	404	405	
			, {6425, 5, 3, 0}, {6424, 5, 4, 0}, {6424, 5, 5, 0}// 406	407	408	
			, {6424, 5, 6, 0}, {6424, 5, 7, 0}, {6424, 5, 8, 0}// 409	410	411	
			, {27, -7, -5, 20}, {27, -7, -4, 20}, {27, -7, -3, 20}// 412	413	414	
			, {27, -7, -2, 20}, {27, -7, -1, 20}, {27, -7, 0, 20}// 415	416	417	
			, {28, -6, 0, 20}, {37, -5, 0, 20}, {37, -4, 0, 20}// 418	419	420	
			, {37, -3, 0, 20}, {37, -2, 0, 20}, {37, -1, 0, 20}// 421	422	423	
			, {37, 0, 0, 20}, {37, 1, 0, 20}, {37, 2, 0, 20}// 424	425	426	
			, {38, 3, -5, 20}, {38, 3, -4, 20}, {38, 3, -3, 20}// 427	428	429	
			, {38, 3, -2, 20}, {38, 3, -1, 20}, {26, 3, 0, 20}// 430	431	432	
			, {10459, 0, -3, 49}, {10456, -1, -3, 49}, {10456, -2, -3, 49}// 433	434	435	
			, {10468, -3, -3, 49}, {10452, 1, -2, 46}, {10457, 0, -2, 46}// 436	437	438	
			, {10457, -1, -2, 46}, {10457, -2, -2, 46}, {10457, -3, -2, 46}// 439	440	441	
			, {10454, -4, -2, 46}, {10441, 1, -3, 46}, {10442, -4, -3, 46}// 442	443	444	
			, {10455, 1, -4, 46}, {10458, 0, -4, 46}, {10458, -1, -4, 46}// 445	446	447	
			, {10458, -2, -4, 46}, {10458, -3, -4, 46}, {10453, -4, -4, 46}// 448	449	450	
			, {10452, 2, -1, 43}, {10457, 1, -1, 43}, {10457, 0, -1, 43}// 451	452	453	
			, {10457, -1, -1, 43}, {10457, -2, -1, 43}, {10457, -3, -1, 43}// 454	455	456	
			, {10457, -4, -1, 43}, {10454, -5, -1, 43}, {10441, 2, -2, 43}// 457	458	459	
			, {10442, -5, -2, 43}, {10441, 2, -3, 43}, {10442, -5, -3, 43}// 460	461	462	
			, {10441, 2, -4, 43}, {10442, -5, -4, 43}, {10455, 2, -5, 43}// 463	464	465	
			, {10458, 1, -5, 43}, {10458, 0, -5, 43}, {10458, -1, -5, 43}// 466	467	468	
			, {10458, -2, -5, 43}, {10458, -3, -5, 43}, {10458, -4, -5, 43}// 469	470	471	
			, {10453, -5, -5, 43}, {10452, 3, 0, 40}, {10457, 2, 0, 40}// 472	473	474	
			, {10457, 1, 0, 40}, {10457, 0, 0, 40}, {10457, -1, 0, 40}// 475	476	477	
			, {10457, -2, 0, 40}, {10457, -3, 0, 40}, {10457, -4, 0, 40}// 478	479	480	
			, {10457, -5, 0, 40}, {10454, -6, 0, 40}, {10441, 3, -1, 40}// 481	482	483	
			, {10442, -6, -1, 40}, {10441, 3, -2, 40}, {10442, -6, -2, 40}// 484	485	486	
			, {10441, 3, -3, 40}, {10442, -6, -3, 40}, {10441, 3, -4, 40}// 487	488	489	
			, {10442, -6, -4, 40}, {10441, 3, -5, 40}, {10442, -6, -5, 40}// 490	491	492	
			, {10452, 4, 1, 37}, {10457, 3, 1, 37}, {10457, 2, 1, 37}// 493	494	495	
			, {10457, 1, 1, 37}, {10457, 0, 1, 37}, {10457, -1, 1, 37}// 496	497	498	
			, {10457, -2, 1, 37}, {10457, -3, 1, 37}, {10457, -4, 1, 37}// 499	500	501	
			, {10457, -5, 1, 37}, {10457, -6, 1, 37}, {10454, -7, 1, 37}// 502	503	504	
			, {10441, 4, 0, 37}, {10442, -7, 0, 37}, {10441, 4, -1, 37}// 505	506	507	
			, {10442, -7, -1, 37}, {10441, 4, -2, 37}, {10442, -7, -2, 37}// 508	509	510	
			, {10441, 4, -3, 37}, {10442, -7, -3, 37}, {10441, 4, -4, 37}// 511	512	513	
			, {10442, -7, -4, 37}, {10441, 4, -5, 37}, {10442, -7, -5, 37}// 514	515	516	
			, {10454, 5, -3, 20}, {10442, 5, -4, 20}, {10442, 5, -5, 20}// 517	518	519	
			, {10457, 5, -2, 17}, {10454, 4, -2, 17}, {10442, 4, -3, 17}// 520	521	522	
			, {10442, 4, -4, 17}, {10442, 4, -5, 17}, {1200, 6, -7, 0}// 523	524	525	
			, {1193, 6, -6, 0}, {1200, 7, -7, 0}, {1196, 7, -6, 0}// 526	527	528	
			, {1203, 8, -7, 0}, {1199, 8, -6, 0}, {6013, 9, -7, 0}// 529	530	531	
			, {6013, 9, -6, 0}, {28, 6, -8, 0}, {28, 7, -8, 0}// 532	533	534	
			, {28, 8, -8, 0}, {27, 8, -7, 0}, {49, 9, -8, 0}// 535	536	538	
			, {50, 9, -7, 0}, {50, 9, -6, 0}, {10455, 8, -6, 20}// 539	540	541	
			, {10458, 7, -6, 20}, {10458, 6, -6, 20}, {10441, 9, -6, 17}// 542	543	544	
			, {10455, 9, -7, 17}, {10458, 8, -7, 17}, {10458, 7, -7, 17}// 545	546	547	
			, {10458, 6, -7, 17}, {1316, 9, -6, 0}, {1312, 9, -7, 0}// 548	549	550	
			, {1195, 6, -5, 0}, {1193, 6, -4, 0}, {1198, 6, -3, 0}// 551	552	553	
			, {1316, 6, -2, 0}, {1312, 6, -1, 0}, {1316, 6, 0, 0}// 554	555	556	
			, {1312, 6, 1, 0}, {1316, 6, 2, 0}, {1307, 6, 3, 0}// 557	558	559	
			, {1307, 6, 4, 0}, {1307, 6, 5, 0}, {1307, 6, 6, 0}// 560	561	562	
			, {1307, 6, 7, 0}, {1307, 6, 8, 0}, {1312, 6, 9, 0}// 563	564	565	
			, {1193, 7, -5, 0}, {1198, 7, -3, 0}, {1312, 7, -2, 0}// 566	567	568	
			, {1316, 7, -1, 0}, {1316, 7, 0, 0}, {1312, 7, 1, 0}// 569	570	571	
			, {1312, 7, 2, 0}, {1312, 7, 3, 0}, {1313, 7, 4, 0}// 572	573	574	
			, {1312, 7, 5, 0}, {1316, 7, 6, 0}, {1316, 7, 7, 0}// 575	576	577	
			, {1316, 7, 8, 0}, {1312, 7, 9, 0}, {1199, 8, -5, 0}// 578	579	580	
			, {1199, 8, -4, 0}, {1201, 8, -3, 0}, {1312, 8, -2, 0}// 581	582	583	
			, {1312, 8, -1, 0}, {1312, 8, 0, 0}, {1312, 8, 1, 0}// 584	585	586	
			, {1313, 8, 2, 0}, {1316, 8, 3, 0}, {1313, 8, 4, 0}// 587	588	589	
			, {1312, 8, 5, 0}, {1312, 8, 6, 0}, {1316, 8, 7, 0}// 590	591	592	
			, {1316, 8, 8, 0}, {1312, 8, 9, 0}, {6013, 9, -5, 0}// 593	594	595	
			, {6013, 9, -4, 0}, {6013, 9, -3, 0}, {1312, 9, -2, 0}// 596	597	598	
			, {1312, 9, -1, 0}, {1316, 9, 0, 0}, {1312, 9, 1, 0}// 599	600	601	
			, {1312, 9, 2, 0}, {1316, 9, 3, 0}, {1312, 9, 4, 0}// 602	603	604	
			, {1312, 9, 5, 0}, {1312, 9, 6, 0}, {1312, 9, 7, 0}// 605	606	607	
			, {1312, 9, 8, 0}, {1312, 9, 9, 0}, {41, 7, -3, 0}// 608	609	610	
			, {9, 7, 9, 0}, {26, 8, -3, 0}, {9, 8, 1, 0}// 611	614	615	
			, {6425, 8, 2, 0}, {6424, 8, 3, 0}, {6424, 8, 4, 0}// 616	617	618	
			, {6424, 8, 5, 0}, {6424, 8, 6, 0}, {6424, 8, 7, 0}// 619	620	621	
			, {6424, 8, 8, 0}, {9, 8, 9, 0}, {50, 9, -5, 0}// 622	623	624	
			, {50, 9, -4, 0}, {50, 9, -3, 0}, {50, 9, -2, 0}// 625	626	627	
			, {50, 9, -1, 0}, {50, 9, 0, 0}, {7, 9, 1, 0}// 628	629	630	
			, {11, 9, 2, 0}, {13, 9, 3, 0}, {8, 9, 5, 0}// 631	632	634	
			, {8, 9, 6, 0}, {11, 9, 8, 0}, {6, 9, 9, 0}// 635	637	638	
			, {21, 9, 2, 20}, {21, 9, 3, 20}, {21, 9, 4, 20}// 639	640	641	
			, {21, 9, 5, 20}, {21, 9, 6, 20}, {21, 9, 7, 20}// 642	643	644	
			, {21, 9, 8, 20}, {20, 9, 9, 20}, {10452, 7, -4, 23}// 645	646	647	
			, {10454, 6, -4, 23}, {10455, 7, -5, 23}, {10453, 6, -5, 23}// 648	649	650	
			, {11332, 9, 9, 20}, {11332, 9, 8, 20}, {11332, 9, 7, 20}// 651	652	653	
			, {11332, 9, 6, 20}, {11332, 9, 5, 20}, {11332, 9, 4, 20}// 654	655	656	
			, {11332, 9, 3, 20}, {11332, 9, 2, 20}, {10452, 8, -3, 20}// 657	658	659	
			, {10457, 7, -3, 20}, {10457, 6, -3, 20}, {10441, 8, -4, 20}// 660	661	662	
			, {10441, 8, -5, 20}, {11332, 8, 9, 17}, {11332, 8, 8, 17}// 663	664	665	
			, {11332, 8, 7, 17}, {11332, 8, 6, 17}, {11332, 8, 5, 17}// 666	667	668	
			, {11332, 8, 4, 17}, {11332, 8, 3, 17}, {11332, 8, 2, 17}// 669	670	671	
			, {10452, 9, -2, 17}, {10457, 8, -2, 17}, {10457, 7, -2, 17}// 672	673	674	
			, {10457, 6, -2, 17}, {10441, 9, -3, 17}, {10441, 9, -4, 17}// 675	676	677	
			, {10441, 9, -5, 17}, {1312, 9, -3, 0}, {1312, 9, -4, 0}// 678	679	680	
			, {1312, 9, -5, 0}// 681	
		};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new RewardHouse2AddonDeed();
			}
		}

		[ Constructable ]
		public RewardHouse2Addon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 10674, 8, -6, 0, 0, 0, "", 1);// 537
			AddComplexComponent( (BaseAddon) this, 10676, 8, -5, 0, 0, 0, "", 1);// 612
			AddComplexComponent( (BaseAddon) this, 10677, 8, -4, 0, 0, 0, "", 1);// 613
			AddComplexComponent( (BaseAddon) this, 15, 9, 4, 0, 0, 0, "", 1);// 633
			AddComplexComponent( (BaseAddon) this, 15, 9, 7, 0, 0, 0, "", 1);// 636

		}

		public RewardHouse2Addon( Serial serial ) : base( serial )
		{
		}

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource)
        {
            AddComplexComponent(addon, item, xoffset, yoffset, zoffset, hue, lightsource, null, 1);
        }

        private static void AddComplexComponent(BaseAddon addon, int item, int xoffset, int yoffset, int zoffset, int hue, int lightsource, string name, int amount)
        {
            AddonComponent ac;
            ac = new AddonComponent(item);
            if (name != null && name.Length > 0)
                ac.Name = name;
            if (hue != 0)
                ac.Hue = hue;
            if (amount > 1)
            {
                ac.Stackable = true;
                ac.Amount = amount;
            }
            if (lightsource != -1)
                ac.Light = (LightType) lightsource;
            addon.AddComponent(ac, xoffset, yoffset, zoffset);
        }

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class RewardHouse2AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new RewardHouse2Addon();
			}
		}

		[Constructable]
		public RewardHouse2AddonDeed()
		{
			Name = "RewardHouse2";
		}

		public RewardHouse2AddonDeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( 0 ); // Version
		}

		public override void	Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}