
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
	public class MageFortress1Addon : BaseAddon
	{
        private static int[,] m_AddOnSimpleComponents = new int[,] {
			  {1316, -7, -8, 0}, {1316, -6, -8, 0}, {1316, -5, -8, 0}// 1	2	3	
			, {1316, -4, -8, 0}, {1316, -3, -8, 0}, {1316, -2, -8, 0}// 4	5	6	
			, {1316, -1, -8, 0}, {1316, 0, -8, 0}, {1316, 1, -8, 0}// 7	8	9	
			, {1316, 2, -8, 0}, {1316, 3, -8, 0}, {1316, 4, -8, 0}// 10	11	12	
			, {1316, 5, -8, 0}, {1316, 6, -8, 0}, {466, -7, -8, 0}// 13	14	15	
			, {464, -6, -8, 0}, {464, -5, -8, 0}, {464, -4, -8, 0}// 16	17	18	
			, {464, -3, -8, 0}, {464, -2, -8, 0}, {464, -1, -8, 0}// 19	20	21	
			, {464, 0, -8, 0}, {464, 1, -8, 0}, {464, 2, -8, 0}// 22	23	24	
			, {464, 3, -8, 0}, {464, 4, -8, 0}, {464, 5, -8, 0}// 25	26	27	
			, {464, 6, -8, 0}, {466, -7, -8, 20}, {464, -6, -8, 20}// 28	29	30	
			, {464, -5, -8, 20}, {464, -4, -8, 20}, {464, -3, -8, 20}// 31	32	33	
			, {464, -2, -8, 20}, {466, -1, -8, 20}, {464, 0, -8, 20}// 34	35	36	
			, {466, 1, -8, 20}, {464, 2, -8, 20}, {466, 3, -8, 20}// 37	38	39	
			, {464, 4, -8, 20}, {464, 5, -8, 20}, {466, -7, -8, 40}// 40	41	43	
			, {464, -6, -8, 40}, {464, -4, -8, 40}, {464, -2, -8, 40}// 44	46	48	
			, {466, -1, -8, 40}, {466, 0, -8, 40}, {466, 1, -8, 40}// 49	50	51	
			, {466, 2, -8, 40}, {466, 3, -8, 40}, {464, 4, -8, 40}// 52	53	54	
			, {464, 6, -8, 40}, {474, -7, -8, 60}, {491, -6, -8, 60}// 56	57	58	
			, {491, -5, -8, 60}, {491, -4, -8, 60}, {491, -3, -8, 60}// 59	60	61	
			, {474, -2, -8, 60}, {474, -1, -8, 60}, {474, 0, -8, 60}// 62	63	64	
			, {474, 1, -8, 60}, {474, 2, -8, 60}, {474, 3, -8, 60}// 65	66	67	
			, {491, 4, -8, 60}, {491, 5, -8, 60}, {491, 6, -8, 60}// 68	69	70	
			, {1316, -7, -7, 0}, {1316, -7, -6, 0}, {1316, -7, -5, 0}// 71	72	73	
			, {1316, -7, -4, 0}, {1316, -7, -3, 0}, {1313, -7, -2, 0}// 74	75	76	
			, {1313, -7, -1, 0}, {1313, -7, 0, 0}, {1313, -7, 1, 0}// 77	78	79	
			, {1316, -7, 2, 0}, {1316, -7, 3, 0}, {1316, -7, 4, 0}// 80	81	82	
			, {1316, -7, 5, 0}, {1316, -7, 6, 0}, {1316, -7, 7, 0}// 83	84	85	
			, {1316, -7, 8, 0}, {1179, -6, -7, 0}, {1179, -6, -6, 0}// 86	87	88	
			, {1179, -6, -5, 0}, {1179, -6, -4, 0}, {1179, -6, -3, 0}// 89	90	91	
			, {1313, -6, -2, 0}, {1313, -6, -1, 0}, {1313, -6, 0, 0}// 92	93	94	
			, {1313, -6, 1, 0}, {1313, -6, 2, 0}, {1179, -6, 3, 0}// 95	96	97	
			, {1179, -6, 4, 0}, {1179, -6, 5, 0}, {1179, -6, 6, 0}// 98	99	100	
			, {1179, -6, 7, 0}, {1316, -6, 8, 0}, {1179, -5, -7, 0}// 101	102	103	
			, {1180, -5, -6, 0}, {1180, -5, -5, 0}, {1180, -5, -4, 0}// 104	105	106	
			, {1179, -5, -3, 0}, {1179, -5, -2, 0}, {1179, -5, -1, 0}// 107	108	109	
			, {1179, -5, 0, 0}, {1179, -5, 1, 0}, {1179, -5, 2, 0}// 110	111	112	
			, {1179, -5, 3, 0}, {1180, -5, 4, 0}, {1180, -5, 5, 0}// 113	114	115	
			, {1180, -5, 6, 0}, {1179, -5, 7, 0}, {1316, -5, 8, 0}// 116	117	118	
			, {1179, -4, -7, 0}, {1180, -4, -6, 0}, {1180, -4, -5, 0}// 119	120	121	
			, {1180, -4, -4, 0}, {1180, -4, -3, 0}, {1180, -4, -2, 0}// 122	123	124	
			, {1180, -4, -1, 0}, {1180, -4, 0, 0}, {1180, -4, 1, 0}// 125	126	127	
			, {1180, -4, 2, 0}, {1180, -4, 3, 0}, {1180, -4, 4, 0}// 128	129	130	
			, {1180, -4, 5, 0}, {1180, -4, 6, 0}, {1179, -4, 7, 0}// 131	132	133	
			, {1316, -4, 8, 0}, {1179, -3, -7, 0}, {1180, -3, -6, 0}// 134	135	136	
			, {1180, -3, -5, 0}, {1180, -3, -4, 0}, {1180, -3, -3, 0}// 137	138	139	
			, {1180, -3, -2, 0}, {1180, -3, -1, 0}, {1180, -3, 0, 0}// 140	141	142	
			, {1180, -3, 1, 0}, {1180, -3, 2, 0}, {1180, -3, 3, 0}// 143	144	145	
			, {1180, -3, 4, 0}, {1180, -3, 5, 0}, {1180, -3, 6, 0}// 146	147	148	
			, {1179, -3, 7, 0}, {1316, -3, 8, 0}, {1179, -2, -7, 0}// 149	150	151	
			, {1179, -2, -6, 0}, {1180, -2, -5, 0}, {1180, -2, -4, 0}// 152	153	154	
			, {1180, -2, -3, 0}, {1180, -2, -2, 0}, {1180, -2, -1, 0}// 155	156	157	
			, {1180, -2, 0, 0}, {1180, -2, 1, 0}, {1180, -2, 2, 0}// 158	159	160	
			, {1180, -2, 3, 0}, {1179, -2, 4, 0}, {1179, -2, 5, 0}// 161	162	163	
			, {1179, -2, 6, 0}, {1179, -2, 7, 0}, {1316, -2, 8, 0}// 164	165	166	
			, {1316, -1, -7, 0}, {1179, -1, -6, 0}, {1180, -1, -5, 0}// 167	168	169	
			, {1180, -1, -4, 0}, {1180, -1, -3, 0}, {1180, -1, -2, 0}// 170	171	172	
			, {1180, -1, -1, 0}, {1180, -1, 0, 0}, {1180, -1, 1, 0}// 173	174	175	
			, {1180, -1, 2, 0}, {1180, -1, 3, 0}, {1179, -1, 4, 0}// 176	177	178	
			, {1316, -1, 5, 0}, {1316, -1, 6, 0}, {1316, -1, 7, 0}// 179	180	181	
			, {1316, -1, 8, 0}, {10636, 0, -7, 0}, {1179, 0, -6, 0}// 182	183	184	
			, {1180, 0, -5, 0}, {1180, 0, -4, 0}, {1180, 0, -3, 0}// 185	186	187	
			, {1180, 0, -2, 0}, {1180, 0, -1, 0}, {1180, 0, 0, 0}// 188	189	190	
			, {1180, 0, 1, 0}, {1180, 0, 2, 0}, {1180, 0, 3, 0}// 191	192	193	
			, {1179, 0, 4, 0}, {10636, 1, -7, 0}, {1179, 1, -6, 0}// 194	195	196	
			, {1180, 1, -5, 0}, {1180, 1, -4, 0}, {1180, 1, -3, 0}// 197	198	199	
			, {1180, 1, -2, 0}, {1180, 1, -1, 0}, {1180, 1, 0, 0}// 200	201	202	
			, {1180, 1, 1, 0}, {1180, 1, 2, 0}, {1180, 1, 3, 0}// 203	204	205	
			, {1179, 1, 4, 0}, {10636, 2, -7, 0}, {1179, 2, -6, 0}// 206	207	208	
			, {1180, 2, -5, 0}, {1180, 2, -4, 0}, {1180, 2, -3, 0}// 209	210	211	
			, {1180, 2, -2, 0}, {1180, 2, -1, 0}, {1180, 2, 0, 0}// 212	213	214	
			, {1180, 2, 1, 0}, {1180, 2, 2, 0}, {1180, 2, 3, 0}// 215	216	217	
			, {1179, 2, 4, 0}, {1316, 2, 5, 0}, {1316, 2, 6, 0}// 218	219	220	
			, {1316, 2, 7, 0}, {1316, 2, 8, 0}, {1316, 3, -7, 0}// 221	222	223	
			, {1179, 3, -6, 0}, {1180, 3, -5, 0}, {1180, 3, -4, 0}// 224	225	226	
			, {1180, 3, -3, 0}, {1180, 3, -2, 0}, {1180, 3, -1, 0}// 227	228	229	
			, {1180, 3, 0, 0}, {1180, 3, 1, 0}, {1180, 3, 2, 0}// 230	231	232	
			, {1180, 3, 3, 0}, {1179, 3, 4, 0}, {1316, 3, 5, 0}// 233	234	235	
			, {1316, 3, 6, 0}, {1316, 3, 7, 0}, {1316, 3, 8, 0}// 236	237	238	
			, {1179, 4, -7, 0}, {1179, 4, -6, 0}, {1180, 4, -5, 0}// 239	240	241	
			, {1180, 4, -4, 0}, {1180, 4, -3, 0}, {1180, 4, -2, 0}// 242	243	244	
			, {1180, 4, -1, 0}, {1180, 4, 0, 0}, {1180, 4, 1, 0}// 245	246	247	
			, {1180, 4, 2, 0}, {1180, 4, 3, 0}, {1179, 4, 4, 0}// 248	249	250	
			, {1179, 4, 5, 0}, {1179, 4, 6, 0}, {1179, 4, 7, 0}// 251	252	253	
			, {1316, 4, 8, 0}, {1179, 5, -7, 0}, {1180, 5, -6, 0}// 254	255	256	
			, {1180, 5, -5, 0}, {1180, 5, -4, 0}, {1180, 5, -3, 0}// 257	258	259	
			, {1180, 5, -2, 0}, {1180, 5, -1, 0}, {1180, 5, 0, 0}// 260	261	262	
			, {1180, 5, 1, 0}, {1180, 5, 2, 0}, {1180, 5, 3, 0}// 263	264	265	
			, {1180, 5, 4, 0}, {1180, 5, 5, 0}, {1180, 5, 6, 0}// 266	267	268	
			, {1179, 5, 7, 0}, {1179, 5, 8, 0}, {1179, 6, -7, 0}// 269	270	271	
			, {1180, 6, -6, 0}, {1180, 6, -5, 0}, {1180, 6, -4, 0}// 272	273	274	
			, {1180, 6, -3, 0}, {1180, 6, -2, 0}, {1180, 6, -1, 0}// 275	276	277	
			, {1180, 6, 0, 0}, {1180, 6, 1, 0}, {1180, 6, 2, 0}// 278	279	280	
			, {1180, 6, 3, 0}, {1180, 6, 4, 0}, {1180, 6, 5, 0}// 281	282	283	
			, {1180, 6, 6, 0}, {1180, 6, 7, 0}, {1179, 6, 8, 0}// 284	285	286	
			, {1305, -6, -7, 20}, {1305, -6, -6, 20}, {1305, -6, -5, 20}// 287	288	289	
			, {1305, -6, -4, 20}, {1305, -6, -3, 20}, {1279, -6, 2, 20}// 290	291	292	
			, {1276, -6, 3, 20}, {1277, -6, 4, 20}, {1279, -6, 5, 20}// 293	294	295	
			, {1277, -6, 6, 20}, {1277, -6, 7, 20}, {1305, -5, -7, 20}// 296	297	298	
			, {1308, -5, -6, 20}, {1305, -5, -5, 20}, {1305, -5, -4, 20}// 299	300	301	
			, {1305, -5, -3, 20}, {1305, -5, -2, 20}, {1305, -5, -1, 20}// 302	303	304	
			, {1305, -5, 0, 20}, {1305, -5, 1, 20}, {1276, -5, 2, 20}// 305	306	307	
			, {1276, -5, 3, 20}, {1277, -5, 4, 20}, {1277, -5, 5, 20}// 308	309	310	
			, {1279, -5, 6, 20}, {1276, -5, 7, 20}, {1305, -4, -7, 20}// 311	312	313	
			, {1308, -4, -6, 20}, {1305, -4, -5, 20}, {1305, -4, -4, 20}// 314	315	316	
			, {1305, -4, -3, 20}, {1308, -4, -2, 20}, {1308, -4, -1, 20}// 317	318	319	
			, {1305, -4, 0, 20}, {1305, -4, 1, 20}, {1276, -4, 2, 20}// 320	321	322	
			, {1276, -4, 3, 20}, {1277, -4, 4, 20}, {1277, -4, 5, 20}// 323	324	325	
			, {1279, -4, 6, 20}, {1276, -4, 7, 20}, {1305, -3, -7, 20}// 326	327	328	
			, {1305, -3, -6, 20}, {1305, -3, -5, 20}, {1305, -3, -4, 20}// 329	330	331	
			, {1305, -3, -3, 20}, {1305, -3, -2, 20}, {1305, -3, -1, 20}// 332	333	334	
			, {1305, -3, 0, 20}, {1305, -3, 1, 20}, {1276, -3, 2, 20}// 335	336	337	
			, {1277, -3, 3, 20}, {1276, -3, 4, 20}, {1277, -3, 5, 20}// 338	339	340	
			, {1277, -3, 6, 20}, {1277, -3, 7, 20}, {1305, -2, -7, 20}// 341	342	343	
			, {1305, -2, -6, 20}, {1305, -2, -5, 20}, {1305, -2, -4, 20}// 344	345	346	
			, {1305, -2, -3, 20}, {1305, -2, -2, 20}, {1305, -2, -1, 20}// 347	348	349	
			, {1305, -2, 0, 20}, {1305, -2, 1, 20}, {1276, -2, 2, 20}// 350	351	352	
			, {1279, -2, 3, 20}, {1276, -2, 4, 20}, {1276, -2, 5, 20}// 353	354	355	
			, {1276, -2, 6, 20}, {1276, -2, 7, 20}, {1276, -1, -6, 20}// 356	357	358	
			, {1276, -1, -5, 20}, {1276, -1, -4, 20}, {1276, -1, -3, 20}// 359	360	361	
			, {1278, -1, -2, 20}, {1276, -1, -1, 20}, {1279, -1, 0, 20}// 362	363	364	
			, {1276, -1, 1, 20}, {1276, -1, 2, 20}, {1276, -1, 3, 20}// 365	366	367	
			, {1315, -1, 4, 20}, {1276, 0, -6, 20}, {1276, 0, -5, 20}// 368	369	370	
			, {1276, 0, -4, 20}, {1277, 0, -3, 20}, {1279, 0, -2, 20}// 371	372	373	
			, {1276, 0, -1, 20}, {1279, 0, 0, 20}, {1279, 0, 1, 20}// 374	375	376	
			, {1279, 0, 2, 20}, {1276, 0, 3, 20}, {1316, 0, 4, 20}// 377	378	379	
			, {1279, 1, -6, 20}, {1279, 1, -5, 20}, {1279, 1, -4, 20}// 380	381	382	
			, {1279, 1, -3, 20}, {1277, 1, -2, 20}, {1279, 1, -1, 20}// 383	384	385	
			, {1277, 1, 0, 20}, {1279, 1, 1, 20}, {1276, 1, 2, 20}// 386	387	388	
			, {1276, 1, 3, 20}, {1315, 1, 4, 20}, {1279, 2, -6, 20}// 389	390	391	
			, {1279, 2, -5, 20}, {1279, 2, -4, 20}, {1279, 2, -3, 20}// 392	393	394	
			, {1279, 2, -2, 20}, {1277, 2, -1, 20}, {1277, 2, 0, 20}// 395	396	397	
			, {1276, 2, 1, 20}, {1277, 2, 2, 20}, {1276, 2, 3, 20}// 398	399	400	
			, {1316, 2, 4, 20}, {1279, 3, -6, 20}, {1279, 3, -5, 20}// 401	402	403	
			, {1279, 3, -4, 20}, {1279, 3, -3, 20}, {1276, 3, -2, 20}// 404	405	406	
			, {1276, 3, -1, 20}, {1277, 3, 0, 20}, {1276, 3, 1, 20}// 407	408	409	
			, {1279, 3, 2, 20}, {1276, 3, 3, 20}, {1276, 3, 4, 20}// 410	411	412	
			, {10633, 4, -7, 20}, {10616, 4, -6, 20}, {10792, 4, -5, 20}// 413	414	415	
			, {10791, 4, -4, 20}, {10633, 4, -3, 20}, {10788, 4, -2, 20}// 416	417	418	
			, {10787, 4, -1, 20}, {10616, 4, 0, 20}, {1278, 4, 1, 20}// 419	420	421	
			, {1276, 4, 2, 20}, {1279, 4, 3, 20}, {1278, 4, 4, 20}// 422	423	424	
			, {1276, 4, 5, 20}, {1276, 4, 6, 20}, {1276, 4, 7, 20}// 425	426	427	
			, {10616, 5, -7, 20}, {10633, 5, -6, 20}, {10616, 5, -5, 20}// 428	429	430	
			, {10628, 5, -4, 20}, {10616, 5, -3, 20}, {10633, 5, -2, 20}// 431	432	433	
			, {10616, 5, -1, 20}, {10633, 5, 0, 20}, {1276, 5, 1, 20}// 434	435	436	
			, {1276, 5, 2, 20}, {1276, 5, 3, 20}, {1277, 5, 4, 20}// 437	438	439	
			, {1276, 5, 5, 20}, {1276, 5, 6, 20}, {1276, 5, 7, 20}// 440	441	442	
			, {10628, 6, -7, 20}, {10790, 6, -6, 20}, {10633, 6, -5, 20}// 443	444	445	
			, {10786, 6, -4, 20}, {10633, 6, -3, 20}, {10792, 6, -2, 20}// 446	447	448	
			, {10791, 6, -1, 20}, {10616, 6, 0, 20}, {1276, 6, 1, 20}// 449	450	451	
			, {1276, 6, 2, 20}, {1276, 6, 3, 20}, {1276, 6, 4, 20}// 452	453	454	
			, {1277, 6, 5, 20}, {1276, 6, 6, 20}, {1276, 6, 7, 20}// 455	456	457	
			, {1180, -6, -7, 40}, {1180, -6, -6, 40}, {1180, -6, -5, 40}// 458	459	460	
			, {1180, -6, -4, 40}, {1180, -6, -3, 40}, {1180, -6, 1, 40}// 461	462	463	
			, {1180, -6, 2, 40}, {1180, -6, 3, 40}, {1180, -6, 4, 40}// 464	465	466	
			, {1180, -6, 5, 40}, {1180, -6, 6, 40}, {1313, -6, 7, 40}// 467	468	469	
			, {1180, -5, -7, 40}, {1180, -5, -6, 40}, {1180, -5, -5, 40}// 470	471	472	
			, {1180, -5, -4, 40}, {1180, -5, -3, 40}, {1180, -5, -2, 40}// 473	474	475	
			, {1180, -5, -1, 40}, {1180, -5, 0, 40}, {1180, -5, 1, 40}// 476	477	478	
			, {1180, -5, 2, 40}, {1180, -5, 3, 40}, {1180, -5, 4, 40}// 479	480	481	
			, {1180, -5, 5, 40}, {1180, -5, 6, 40}, {1313, -5, 7, 40}// 482	483	484	
			, {1180, -4, -7, 40}, {1180, -4, -6, 40}, {1180, -4, -5, 40}// 485	486	487	
			, {1180, -4, -4, 40}, {1180, -4, -3, 40}, {1180, -4, -2, 40}// 488	489	490	
			, {1180, -4, -1, 40}, {1180, -4, 0, 40}, {1180, -4, 1, 40}// 491	492	493	
			, {1180, -4, 2, 40}, {1180, -4, 3, 40}, {1180, -4, 4, 40}// 494	495	496	
			, {1180, -4, 5, 40}, {1180, -4, 6, 40}, {1313, -4, 7, 40}// 497	498	499	
			, {1180, -3, -7, 40}, {1180, -3, -6, 40}, {1180, -3, -5, 40}// 500	501	502	
			, {1180, -3, -4, 40}, {1180, -3, -3, 40}, {1180, -3, -2, 40}// 503	504	505	
			, {1180, -3, -1, 40}, {1180, -3, 0, 40}, {1180, -3, 1, 40}// 506	507	508	
			, {1180, -3, 2, 40}, {1180, -3, 3, 40}, {1180, -3, 4, 40}// 509	510	511	
			, {1180, -3, 5, 40}, {1180, -3, 6, 40}, {1313, -3, 7, 40}// 512	513	514	
			, {1180, -2, -7, 40}, {1180, -2, -6, 40}, {1180, -2, -5, 40}// 515	516	517	
			, {1180, -2, -4, 40}, {1180, -2, -3, 40}, {1180, -2, -2, 40}// 518	519	520	
			, {1180, -2, -1, 40}, {1180, -2, 0, 40}, {1180, -2, 1, 40}// 521	522	523	
			, {1180, -2, 2, 40}, {1180, -2, 3, 40}, {1180, -2, 4, 40}// 524	525	526	
			, {1180, -2, 5, 40}, {1180, -2, 6, 40}, {1313, -2, 7, 40}// 527	528	529	
			, {1180, -1, -6, 40}, {1180, -1, -5, 40}, {1180, -1, -4, 40}// 530	531	532	
			, {1180, -1, -3, 40}, {1180, -1, -2, 40}, {1180, -1, -1, 40}// 533	534	535	
			, {1180, -1, 0, 40}, {1180, -1, 1, 40}, {1180, -1, 2, 40}// 536	537	538	
			, {1180, -1, 3, 40}, {1180, -1, 4, 40}, {1180, 0, -6, 40}// 539	540	541	
			, {1180, 0, -5, 40}, {1180, 0, -4, 40}, {1180, 0, -3, 40}// 542	543	544	
			, {1180, 0, -2, 40}, {1180, 0, -1, 40}, {1180, 0, 0, 40}// 545	546	547	
			, {1180, 0, 1, 40}, {1180, 0, 2, 40}, {1180, 0, 3, 40}// 548	549	550	
			, {1180, 0, 4, 40}, {1180, 1, -6, 40}, {1180, 1, -5, 40}// 551	552	553	
			, {1180, 1, -4, 40}, {1180, 1, -3, 40}, {1180, 1, -2, 40}// 554	555	556	
			, {1180, 1, -1, 40}, {1180, 1, 0, 40}, {1180, 1, 1, 40}// 557	558	559	
			, {1180, 1, 2, 40}, {1180, 1, 3, 40}, {1180, 1, 4, 40}// 560	561	562	
			, {1180, 2, -6, 40}, {1180, 2, -5, 40}, {1180, 2, -4, 40}// 563	564	565	
			, {1180, 2, -3, 40}, {1180, 2, -2, 40}, {1180, 2, -1, 40}// 566	567	568	
			, {1180, 2, 0, 40}, {1180, 2, 1, 40}, {1180, 2, 2, 40}// 569	570	571	
			, {1180, 2, 3, 40}, {1180, 2, 4, 40}, {1180, 3, -6, 40}// 572	573	574	
			, {1180, 3, -5, 40}, {1180, 3, -4, 40}, {1180, 3, -3, 40}// 575	576	577	
			, {1180, 3, -2, 40}, {1180, 3, -1, 40}, {1180, 3, 0, 40}// 578	579	580	
			, {1180, 3, 1, 40}, {1180, 3, 2, 40}, {1180, 3, 3, 40}// 581	582	583	
			, {1180, 3, 4, 40}, {1180, 4, -7, 40}, {1180, 4, -6, 40}// 584	585	586	
			, {1180, 4, -5, 40}, {1180, 4, -4, 40}, {1180, 4, -3, 40}// 587	588	589	
			, {1180, 4, -2, 40}, {1180, 4, -1, 40}, {1180, 4, 0, 40}// 590	591	592	
			, {1180, 4, 1, 40}, {1180, 4, 2, 40}, {1180, 4, 3, 40}// 593	594	595	
			, {1180, 4, 4, 40}, {1180, 4, 5, 40}, {1180, 4, 6, 40}// 596	597	598	
			, {1313, 4, 7, 40}, {1180, 5, -7, 40}, {1180, 5, -6, 40}// 599	600	601	
			, {1180, 5, -5, 40}, {1180, 5, -4, 40}, {1180, 5, -3, 40}// 602	603	604	
			, {1180, 5, -2, 40}, {1180, 5, -1, 40}, {1180, 5, 0, 40}// 605	606	607	
			, {1180, 5, 1, 40}, {1180, 5, 2, 40}, {1180, 5, 3, 40}// 608	609	610	
			, {1180, 5, 4, 40}, {1180, 5, 5, 40}, {1180, 5, 6, 40}// 611	612	613	
			, {1313, 5, 7, 40}, {1180, 6, -7, 40}, {1180, 6, -6, 40}// 614	615	616	
			, {1180, 6, -5, 40}, {1180, 6, -4, 40}, {1180, 6, -3, 40}// 617	618	619	
			, {1180, 6, 2, 40}, {1180, 6, 3, 40}, {1180, 6, 4, 40}// 620	621	622	
			, {1180, 6, 5, 40}, {1180, 6, 6, 40}, {1313, 6, 7, 40}// 623	624	625	
			, {1315, -6, -7, 60}, {1315, -6, -6, 60}, {1315, -6, -5, 60}// 626	627	628	
			, {1315, -6, -4, 60}, {1315, -6, -3, 60}, {1313, -6, -2, 60}// 629	630	631	
			, {1313, -6, -1, 60}, {1313, -6, 0, 60}, {1313, -6, 1, 60}// 632	633	634	
			, {1315, -6, 2, 60}, {1315, -6, 3, 60}, {1313, -6, 4, 60}// 635	636	637	
			, {1315, -6, 5, 60}, {1315, -6, 6, 60}, {1315, -5, -7, 60}// 638	639	640	
			, {1315, -5, -6, 60}, {1313, -5, -5, 60}, {1315, -5, -4, 60}// 641	642	643	
			, {1315, -5, -3, 60}, {1315, -5, -2, 60}, {1315, -5, -1, 60}// 644	645	646	
			, {1315, -5, 0, 60}, {1315, -5, 1, 60}, {1315, -5, 2, 60}// 647	648	649	
			, {1316, -5, 3, 60}, {1313, -5, 4, 60}, {1315, -5, 5, 60}// 650	651	652	
			, {1315, -5, 6, 60}, {1315, -4, -7, 60}, {1316, -4, -6, 60}// 653	654	655	
			, {1316, -4, -5, 60}, {1314, -4, -4, 60}, {1315, -4, -3, 60}// 656	657	658	
			, {1315, -4, -2, 60}, {1313, -4, -1, 60}, {1316, -4, 0, 60}// 659	660	661	
			, {1315, -4, 1, 60}, {1316, -4, 2, 60}, {1316, -4, 3, 60}// 662	663	664	
			, {1313, -4, 4, 60}, {1315, -4, 5, 60}, {1315, -4, 6, 60}// 665	666	667	
			, {1315, -3, -7, 60}, {1315, -3, -6, 60}, {1316, -3, -5, 60}// 668	669	670	
			, {1316, -3, -4, 60}, {1315, -3, -3, 60}, {1315, -3, -2, 60}// 671	672	673	
			, {1315, -3, -1, 60}, {1315, -3, 0, 60}, {1315, -3, 1, 60}// 674	675	676	
			, {1315, -3, 2, 60}, {1316, -3, 3, 60}, {1313, -3, 4, 60}// 677	678	679	
			, {1315, -3, 5, 60}, {1315, -3, 6, 60}, {1315, -2, -7, 60}// 680	681	682	
			, {1315, -2, -6, 60}, {1315, -2, -5, 60}, {1316, -2, -4, 60}// 683	684	685	
			, {1314, -2, -3, 60}, {1314, -2, -2, 60}, {1315, -2, -1, 60}// 686	687	688	
			, {1315, -2, 0, 60}, {1315, -2, 1, 60}, {1315, -2, 2, 60}// 689	690	691	
			, {1315, -2, 3, 60}, {1315, -2, 4, 60}, {1315, -2, 5, 60}// 692	693	694	
			, {1315, -2, 6, 60}, {1315, -1, -6, 60}, {1315, -1, -5, 60}// 695	696	697	
			, {1315, -1, -4, 60}, {1315, -1, -3, 60}, {1313, -1, -2, 60}// 698	699	700	
			, {1315, -1, -1, 60}, {1316, -1, 0, 60}, {1315, -1, 1, 60}// 701	702	703	
			, {1316, -1, 2, 60}, {1315, -1, 3, 60}, {1315, -1, 4, 60}// 704	705	706	
			, {1313, 0, -6, 60}, {1313, 0, -5, 60}, {1315, 0, -4, 60}// 707	708	709	
			, {1316, 0, -3, 60}, {1316, 0, -2, 60}, {1313, 0, -1, 60}// 710	711	712	
			, {1315, 0, 0, 60}, {1313, 0, 1, 60}, {1316, 0, 2, 60}// 713	714	715	
			, {1315, 0, 3, 60}, {1315, 0, 4, 60}, {1315, 1, -6, 60}// 716	717	718	
			, {1315, 1, -5, 60}, {1315, 1, -4, 60}, {1315, 1, -3, 60}// 719	720	721	
			, {1316, 1, -2, 60}, {1315, 1, -1, 60}, {1316, 1, 0, 60}// 722	723	724	
			, {1315, 1, 1, 60}, {1315, 1, 2, 60}, {1316, 1, 3, 60}// 725	726	727	
			, {1315, 1, 4, 60}, {1315, 2, -6, 60}, {1315, 2, -5, 60}// 728	729	730	
			, {1315, 2, -4, 60}, {1315, 2, -3, 60}, {1316, 2, -2, 60}// 731	732	733	
			, {1315, 2, -1, 60}, {1315, 2, 0, 60}, {1313, 2, 1, 60}// 734	735	736	
			, {1316, 2, 2, 60}, {1315, 2, 3, 60}, {1315, 2, 4, 60}// 737	738	739	
			, {1315, 3, -6, 60}, {1315, 3, -5, 60}, {1315, 3, -4, 60}// 740	741	742	
			, {1315, 3, -3, 60}, {1313, 3, -2, 60}, {1315, 3, -1, 60}// 743	744	745	
			, {1315, 3, 0, 60}, {1313, 3, 1, 60}, {1316, 3, 2, 60}// 746	747	748	
			, {1315, 3, 3, 60}, {1315, 3, 4, 60}, {1313, 4, -7, 60}// 749	750	751	
			, {1313, 4, -6, 60}, {1313, 4, -5, 60}, {1313, 4, -4, 60}// 752	753	754	
			, {1313, 4, -3, 60}, {1313, 4, -2, 60}, {1315, 4, -1, 60}// 755	756	757	
			, {1315, 4, 0, 60}, {1313, 4, 1, 60}, {1313, 4, 2, 60}// 758	759	760	
			, {1313, 4, 3, 60}, {1313, 4, 4, 60}, {1315, 4, 5, 60}// 761	762	763	
			, {1315, 4, 6, 60}, {1313, 5, -7, 60}, {1313, 5, -6, 60}// 764	765	766	
			, {1316, 5, -5, 60}, {1316, 5, -4, 60}, {1313, 5, -3, 60}// 767	768	769	
			, {1313, 5, -2, 60}, {1313, 5, -1, 60}, {1315, 5, 0, 60}// 770	771	772	
			, {1315, 5, 1, 60}, {1315, 5, 2, 60}, {1316, 5, 3, 60}// 773	774	775	
			, {1315, 5, 4, 60}, {1315, 5, 5, 60}, {1315, 5, 6, 60}// 776	777	778	
			, {1313, 6, -7, 60}, {1313, 6, -6, 60}, {1316, 6, -5, 60}// 779	780	781	
			, {1313, 6, -4, 60}, {1313, 6, -3, 60}, {1315, 6, 2, 60}// 782	783	784	
			, {1315, 6, 3, 60}, {1315, 6, 4, 60}, {1315, 6, 5, 60}// 785	786	787	
			, {1315, 6, 6, 60}, {466, -8, -7, 0}, {465, -8, -6, 0}// 788	789	790	
			, {466, -8, -5, 0}, {465, -8, -4, 0}, {2148, -8, 1, 0}// 791	792	793	
			, {466, -8, 2, 0}, {465, -8, 3, 0}, {466, -8, 4, 0}// 794	795	796	
			, {466, -8, 5, 0}, {465, -8, 6, 0}, {466, -8, 8, 0}// 797	798	799	
			, {463, -7, -7, 0}, {463, -7, -6, 0}, {463, -7, -5, 0}// 800	801	802	
			, {463, -7, -4, 0}, {465, -7, -3, 0}, {466, -7, -2, 0}// 803	804	805	
			, {466, -7, -1, 0}, {466, -7, 0, 0}, {466, -7, 1, 0}// 806	807	808	
			, {463, -7, 2, 0}, {463, -7, 3, 0}, {465, -7, 4, 0}// 809	810	811	
			, {463, -7, 5, 0}, {463, -7, 6, 0}, {465, -7, 7, 0}// 812	813	814	
			, {486, -7, 8, 0}, {464, -6, -3, 0}, {465, -6, -2, 0}// 815	816	817	
			, {465, -6, -1, 0}, {465, -6, 0, 0}, {463, -6, 1, 0}// 818	819	820	
			, {463, -6, 2, 0}, {464, -6, 7, 0}, {465, -6, 8, 0}// 821	822	823	
			, {464, -5, 7, 0}, {463, -5, 8, 0}, {464, -4, 7, 0}// 824	825	826	
			, {465, -4, 8, 0}, {464, -3, 7, 0}, {463, -3, 8, 0}// 827	828	829	
			, {465, -2, -7, 0}, {486, -2, -6, 0}, {466, -2, 4, 0}// 830	831	832	
			, {465, -2, 5, 0}, {465, -2, 6, 0}, {463, -2, 7, 0}// 833	834	835	
			, {463, -1, -7, 0}, {486, -1, -6, 0}, {464, -1, 4, 0}// 836	837	838	
			, {466, -1, 5, 0}, {466, -1, 6, 0}, {474, -1, 7, 0}// 839	840	841	
			, {474, -1, 8, 0}, {464, 0, 4, 0}, {1928, 0, 5, 0}// 842	843	844	
			, {1928, 0, 6, 0}, {1928, 0, 7, 0}, {1929, 0, 8, 0}// 845	846	847	
			, {464, 1, 4, 0}, {1928, 1, 5, 0}, {1928, 1, 6, 0}// 848	849	850	
			, {1928, 1, 7, 0}, {1929, 1, 8, 0}, {465, 2, -7, 0}// 851	852	853	
			, {486, 2, -6, 0}, {464, 2, 4, 0}, {466, 2, 5, 0}// 854	855	856	
			, {466, 2, 6, 0}, {474, 2, 7, 0}, {474, 2, 8, 0}// 857	858	859	
			, {463, 3, -7, 0}, {486, 3, -6, 0}, {464, 3, 4, 0}// 860	861	862	
			, {465, 3, 5, 0}, {465, 3, 6, 0}, {465, 3, 7, 0}// 863	864	865	
			, {463, 4, -7, 0}, {464, 4, 7, 0}, {465, 4, 8, 0}// 866	867	868	
			, {464, 5, 8, 0}, {465, 6, -7, 0}, {466, -8, -7, 20}// 869	870	871	
			, {465, -8, -6, 20}, {466, -8, -5, 20}, {465, -8, -4, 20}// 872	873	874	
			, {466, -8, 2, 20}, {465, -8, 3, 20}, {466, -8, 4, 20}// 875	876	877	
			, {466, -8, 5, 20}, {465, -8, 6, 20}, {474, -8, 8, 20}// 878	879	880	
			, {463, -7, -7, 20}, {463, -7, -6, 20}, {463, -7, -5, 20}// 881	882	883	
			, {463, -7, -4, 20}, {465, -7, -3, 20}, {466, -7, 1, 20}// 884	885	886	
			, {463, -7, 2, 20}, {463, -7, 3, 20}, {463, -7, 5, 20}// 887	888	890	
			, {463, -7, 6, 20}, {465, -7, 7, 20}, {464, -6, -3, 20}// 891	892	893	
			, {465, -6, -2, 20}, {463, -6, 1, 20}, {464, -6, 7, 20}// 894	897	898	
			, {465, -6, 8, 20}, {464, -5, -3, 20}, {464, -5, 1, 20}// 899	900	901	
			, {464, -5, 7, 20}, {463, -5, 8, 20}, {2083, -4, -3, 20}// 902	903	904	
			, {2083, -4, 1, 20}, {464, -4, 7, 20}, {465, -4, 8, 20}// 905	906	907	
			, {2083, -3, -3, 20}, {2083, -3, 1, 20}, {464, -3, 7, 20}// 908	909	910	
			, {463, -3, 8, 20}, {465, -2, -7, 20}, {465, -2, -6, 20}// 911	912	913	
			, {2081, -2, -5, 20}, {463, -2, -3, 20}, {2081, -2, -2, 20}// 914	915	916	
			, {2081, -2, 0, 20}, {463, -2, 1, 20}, {466, -2, 3, 20}// 917	918	919	
			, {465, -2, 4, 20}, {465, -2, 5, 20}, {465, -2, 6, 20}// 920	921	922	
			, {463, -2, 7, 20}, {463, -1, -7, 20}, {464, -1, 3, 20}// 923	924	925	
			, {464, -1, 4, 20}, {474, -1, 5, 20}, {474, -1, 6, 20}// 926	927	928	
			, {463, 0, -7, 20}, {470, 0, 4, 20}, {463, 1, -7, 20}// 929	930	931	
			, {463, 2, -7, 20}, {464, 2, 3, 20}, {469, 2, 4, 20}// 932	933	934	
			, {474, 2, 5, 20}, {474, 2, 6, 20}, {463, 3, -7, 20}// 935	936	937	
			, {2121, 3, -6, 20}, {2121, 3, -4, 20}, {2121, 3, -3, 20}// 938	939	940	
			, {2121, 3, -2, 20}, {2121, 3, -1, 20}, {2121, 3, 0, 20}// 941	942	943	
			, {464, 3, 3, 20}, {463, 3, 4, 20}, {465, 3, 5, 20}// 944	945	946	
			, {465, 3, 6, 20}, {465, 3, 7, 20}, {2083, 4, 0, 20}// 947	948	949	
			, {464, 4, 3, 20}, {464, 4, 7, 20}, {465, 4, 8, 20}// 950	951	952	
			, {2083, 5, 0, 20}, {464, 5, 7, 20}, {463, 5, 8, 20}// 953	954	955	
			, {2083, 6, 0, 20}, {466, 6, 1, 20}, {465, 6, 2, 20}// 956	957	958	
			, {463, 6, 3, 20}, {465, 6, 4, 20}, {486, 6, 5, 20}// 959	960	961	
			, {464, 6, 7, 20}, {463, 6, 8, 20}, {474, -8, 4, 40}// 962	963	964	
			, {465, -7, -7, 40}, {465, -7, -6, 40}, {465, -7, -4, 40}// 965	966	968	
			, {465, -7, -3, 40}, {466, -7, 1, 40}, {465, -7, 2, 40}// 969	970	971	
			, {465, -7, 3, 40}, {465, -7, 5, 40}, {465, -7, 6, 40}// 972	974	975	
			, {474, -7, 7, 40}, {464, -6, -3, 40}, {465, -6, -2, 40}// 976	977	978	
			, {463, -6, 1, 40}, {464, -6, 6, 40}, {479, -6, 7, 40}// 981	982	983	
			, {481, -6, 8, 40}, {464, -5, 6, 40}, {479, -5, 7, 40}// 984	985	986	
			, {481, -5, 8, 40}, {464, -4, 6, 40}, {479, -4, 7, 40}// 987	988	989	
			, {481, -4, 8, 40}, {464, -3, 6, 40}, {479, -3, 7, 40}// 990	991	992	
			, {481, -3, 8, 40}, {465, -2, -7, 40}, {466, -2, 4, 40}// 993	994	995	
			, {465, -2, 5, 40}, {463, -2, 6, 40}, {474, -2, 7, 40}// 996	997	998	
			, {464, -1, -7, 40}, {464, -1, 4, 40}, {464, 0, -7, 40}// 999	1000	1001	
			, {464, 1, -7, 40}, {464, 1, 4, 40}, {464, 2, -7, 40}// 1003	1004	1005	
			, {463, 3, -7, 40}, {464, 3, 4, 40}, {465, 3, 5, 40}// 1007	1008	1009	
			, {465, 3, 6, 40}, {474, 3, 7, 40}, {464, 4, 6, 40}// 1010	1011	1012	
			, {479, 4, 7, 40}, {481, 4, 8, 40}, {466, 5, -3, 40}// 1013	1014	1015	
			, {465, 5, -2, 40}, {465, 5, -1, 40}, {465, 5, 0, 40}// 1016	1017	1018	
			, {486, 5, 1, 40}, {464, 5, 6, 40}, {479, 5, 7, 40}// 1019	1020	1021	
			, {481, 5, 8, 40}, {464, 6, -3, 40}, {1848, 6, -2, 40}// 1022	1023	1024	
			, {1848, 6, -1, 40}, {1848, 6, 0, 40}, {1849, 6, 1, 40}// 1025	1026	1027	
			, {464, 6, 6, 40}, {479, 6, 7, 40}, {481, 6, 8, 40}// 1028	1029	1030	
			, {491, -7, -7, 60}, {491, -7, -6, 60}, {491, -7, -5, 60}// 1031	1032	1033	
			, {491, -7, -4, 60}, {474, -7, -3, 60}, {474, -7, 1, 60}// 1034	1035	1036	
			, {491, -7, 2, 60}, {491, -7, 3, 60}, {491, -7, 4, 60}// 1037	1038	1039	
			, {490, -7, 5, 60}, {474, -7, 6, 60}, {491, -6, -3, 60}// 1040	1041	1042	
			, {491, -6, -2, 60}, {491, -6, -1, 60}, {491, -6, 0, 60}// 1043	1044	1045	
			, {491, -6, 1, 60}, {489, -6, 5, 60}, {490, -6, 6, 60}// 1046	1047	1048	
			, {481, -6, 7, 60}, {489, -5, 5, 60}, {474, -5, 6, 60}// 1049	1050	1051	
			, {481, -5, 7, 60}, {489, -4, 5, 60}, {474, -4, 6, 60}// 1052	1053	1054	
			, {481, -4, 7, 60}, {489, -3, 5, 60}, {490, -3, 6, 60}// 1055	1056	1057	
			, {481, -3, 7, 60}, {491, -2, -7, 60}, {491, -2, 4, 60}// 1058	1059	1060	
			, {488, -2, 5, 60}, {474, -2, 6, 60}, {491, -1, -7, 60}// 1061	1062	1063	
			, {489, -1, 4, 60}, {491, 0, -7, 60}, {489, 0, 4, 60}// 1064	1065	1066	
			, {491, 1, -7, 60}, {489, 1, 4, 60}, {491, 2, -7, 60}// 1067	1068	1069	
			, {489, 2, 4, 60}, {491, 3, -7, 60}, {489, 3, 4, 60}// 1070	1071	1072	
			, {490, 3, 5, 60}, {474, 3, 6, 60}, {489, 4, 5, 60}// 1073	1074	1075	
			, {490, 4, 6, 60}, {481, 4, 7, 60}, {2284, 5, -2, 60}// 1076	1077	1078	
			, {2284, 5, -1, 60}, {2284, 5, 0, 60}, {2284, 5, 1, 60}// 1079	1080	1081	
			, {2284, 5, 2, 60}, {489, 5, 5, 60}, {474, 5, 6, 60}// 1082	1083	1084	
			, {481, 5, 7, 60}, {2284, 6, 2, 60}, {489, 6, 5, 60}// 1085	1086	1087	
			, {474, 6, 6, 60}, {481, 6, 7, 60}, {1849, 6, -2, 55}// 1088	1089	1090	
			, {1849, 6, -1, 50}, {1848, 6, -2, 50}, {1849, 6, 0, 45}// 1091	1092	1093	
			, {1848, 6, -1, 45}, {1848, 6, -2, 45}, {1929, 1, 5, 15}// 1094	1095	1096	
			, {1929, 0, 5, 15}, {1929, 1, 6, 10}, {1929, 0, 6, 10}// 1097	1098	1099	
			, {1928, 1, 5, 10}, {1928, 0, 5, 10}, {1929, 1, 7, 5}// 1100	1101	1102	
			, {1929, 0, 7, 5}, {1928, 1, 6, 5}, {1928, 0, 6, 5}// 1103	1104	1105	
			, {1928, 1, 5, 5}, {1928, 0, 5, 5}, {1316, 7, -8, 0}// 1106	1107	1108	
			, {1316, 8, -8, 0}, {1316, 9, -8, 0}, {464, 7, -8, 0}// 1109	1110	1111	
			, {464, 8, -8, 0}, {487, 9, -8, 0}, {464, 7, -8, 20}// 1112	1113	1114	
			, {464, 8, -8, 20}, {464, 8, -8, 40}, {491, 7, -8, 60}// 1115	1117	1118	
			, {474, 8, -8, 60}, {1179, 7, -7, 0}, {1180, 7, -6, 0}// 1119	1120	1121	
			, {1180, 7, -5, 0}, {1180, 7, -4, 0}, {1179, 7, -3, 0}// 1122	1123	1124	
			, {1179, 7, -2, 0}, {1179, 7, -1, 0}, {1179, 7, 0, 0}// 1125	1126	1127	
			, {1179, 7, 1, 0}, {1179, 7, 2, 0}, {1180, 7, 3, 0}// 1128	1129	1130	
			, {1180, 7, 4, 0}, {1180, 7, 5, 0}, {1180, 7, 6, 0}// 1131	1132	1133	
			, {1179, 7, 7, 0}, {1179, 7, 8, 0}, {1179, 8, -7, 0}// 1134	1135	1136	
			, {1179, 8, -6, 0}, {1179, 8, -5, 0}, {1179, 8, -4, 0}// 1137	1138	1139	
			, {1179, 8, -3, 0}, {1316, 8, -2, 0}, {1316, 8, -1, 0}// 1140	1141	1142	
			, {1316, 8, 0, 0}, {1316, 8, 1, 0}, {1179, 8, 2, 0}// 1143	1144	1145	
			, {1179, 8, 3, 0}, {1179, 8, 4, 0}, {1179, 8, 5, 0}// 1146	1147	1148	
			, {1179, 8, 6, 0}, {1179, 8, 7, 0}, {1316, 8, 8, 0}// 1149	1150	1151	
			, {1316, 9, -7, 0}, {1316, 9, -6, 0}, {1316, 9, -5, 0}// 1152	1153	1154	
			, {1316, 9, -4, 0}, {1316, 9, -3, 0}, {1316, 9, -2, 0}// 1155	1156	1157	
			, {1316, 9, -1, 0}, {1316, 9, 0, 0}, {1316, 9, 1, 0}// 1158	1159	1160	
			, {1316, 9, 2, 0}, {1316, 9, 3, 0}, {1316, 9, 4, 0}// 1161	1162	1163	
			, {1316, 9, 5, 0}, {1316, 9, 6, 0}, {1316, 9, 7, 0}// 1164	1165	1166	
			, {1316, 9, 8, 0}, {10616, 7, -7, 20}, {10789, 7, -6, 20}// 1167	1168	1169	
			, {10616, 7, -5, 20}, {10785, 7, -4, 20}, {10616, 7, -3, 20}// 1170	1171	1172	
			, {10633, 7, -2, 20}, {10616, 7, -1, 20}, {10633, 7, 0, 20}// 1173	1174	1175	
			, {1276, 7, 1, 20}, {1276, 7, 6, 20}, {1276, 7, 7, 20}// 1176	1177	1178	
			, {10633, 8, -7, 20}, {10616, 8, -6, 20}, {10633, 8, -5, 20}// 1179	1180	1181	
			, {10616, 8, -4, 20}, {10633, 8, -3, 20}, {1276, 8, 2, 20}// 1182	1183	1184	
			, {1278, 8, 3, 20}, {1276, 8, 4, 20}, {1278, 8, 5, 20}// 1185	1186	1187	
			, {1276, 8, 6, 20}, {1276, 8, 7, 20}, {1180, 7, -7, 40}// 1188	1189	1190	
			, {1180, 7, -6, 40}, {1180, 7, -5, 40}, {1180, 7, -4, 40}// 1191	1192	1193	
			, {1180, 7, -3, 40}, {1180, 7, -2, 40}, {1180, 7, -1, 40}// 1194	1195	1196	
			, {1180, 7, 0, 40}, {1180, 7, 1, 40}, {1180, 7, 6, 40}// 1197	1198	1199	
			, {1313, 7, 7, 40}, {1180, 8, -7, 40}, {1180, 8, -6, 40}// 1200	1201	1202	
			, {1180, 8, -5, 40}, {1180, 8, -4, 40}, {1180, 8, -3, 40}// 1203	1204	1205	
			, {1180, 8, 2, 40}, {1180, 8, 3, 40}, {1180, 8, 4, 40}// 1206	1207	1208	
			, {1180, 8, 5, 40}, {1180, 8, 6, 40}, {1313, 8, 7, 40}// 1209	1210	1211	
			, {1313, 7, -7, 60}, {1313, 7, -6, 60}, {1313, 7, -5, 60}// 1212	1213	1214	
			, {1313, 7, -4, 60}, {1313, 7, -3, 60}, {1315, 7, -2, 60}// 1215	1216	1217	
			, {1315, 7, -1, 60}, {1315, 7, 0, 60}, {1315, 7, 1, 60}// 1218	1219	1220	
			, {1315, 7, 2, 60}, {1315, 7, 3, 60}, {1313, 7, 4, 60}// 1221	1222	1223	
			, {1315, 7, 5, 60}, {1315, 7, 6, 60}, {1313, 8, -7, 60}// 1224	1225	1226	
			, {1313, 8, -6, 60}, {1313, 8, -5, 60}, {1313, 8, -4, 60}// 1227	1228	1229	
			, {1313, 8, -3, 60}, {1315, 8, 2, 60}, {1315, 8, 3, 60}// 1230	1231	1232	
			, {1315, 8, 4, 60}, {1315, 8, 5, 60}, {1315, 8, 6, 60}// 1233	1234	1235	
			, {464, 7, -7, 0}, {466, 7, -3, 0}, {465, 7, -2, 0}// 1236	1237	1238	
			, {465, 7, -1, 0}, {465, 7, 0, 0}, {465, 7, 1, 0}// 1239	1240	1241	
			, {466, 7, 7, 0}, {463, 7, 8, 0}, {463, 8, -7, 0}// 1242	1243	1244	
			, {465, 8, -6, 0}, {465, 8, -5, 0}, {465, 8, -4, 0}// 1245	1246	1247	
			, {463, 8, -3, 0}, {477, 8, -2, 0}, {477, 8, -1, 0}// 1248	1249	1250	
			, {477, 8, 0, 0}, {464, 8, 1, 0}, {465, 8, 2, 0}// 1251	1252	1253	
			, {465, 8, 3, 0}, {465, 8, 4, 0}, {465, 8, 5, 0}// 1254	1255	1256	
			, {465, 8, 6, 0}, {463, 8, 7, 0}, {470, 8, 8, 0}// 1257	1258	1259	
			, {464, 9, -7, 0}, {463, 9, -6, 0}, {464, 9, -5, 0}// 1260	1261	1262	
			, {463, 9, -4, 0}, {487, 9, -3, 0}, {487, 9, 1, 0}// 1263	1264	1265	
			, {464, 9, 2, 0}, {463, 9, 3, 0}, {466, 9, 4, 0}// 1266	1267	1268	
			, {464, 9, 5, 0}, {463, 9, 6, 0}, {487, 9, 7, 0}// 1269	1270	1271	
			, {466, 7, -3, 20}, {465, 7, -2, 20}, {463, 7, 1, 20}// 1272	1273	1276	
			, {1848, 7, 2, 20}, {1848, 7, 3, 20}, {1848, 7, 4, 20}// 1277	1278	1279	
			, {1849, 7, 5, 20}, {464, 7, 7, 20}, {463, 7, 8, 20}// 1280	1281	1282	
			, {465, 8, -7, 20}, {465, 8, -6, 20}, {465, 8, -5, 20}// 1283	1284	1285	
			, {465, 8, -4, 20}, {463, 8, -3, 20}, {464, 8, 1, 20}// 1286	1287	1288	
			, {465, 8, 2, 20}, {465, 8, 3, 20}, {465, 8, 4, 20}// 1289	1290	1291	
			, {465, 8, 5, 20}, {465, 8, 6, 20}, {463, 8, 7, 20}// 1292	1293	1294	
			, {474, 8, 8, 20}, {464, 9, -7, 20}, {463, 9, -6, 20}// 1295	1296	1297	
			, {464, 9, -5, 20}, {463, 9, -4, 20}, {464, 9, 2, 20}// 1298	1299	1300	
			, {463, 9, 3, 20}, {466, 9, 4, 20}, {464, 9, 5, 20}// 1301	1302	1303	
			, {463, 9, 6, 20}, {464, 7, -3, 40}, {465, 7, -2, 40}// 1304	1305	1306	
			, {465, 7, 1, 40}, {464, 7, 6, 40}, {479, 7, 7, 40}// 1309	1310	1311	
			, {481, 7, 8, 40}, {465, 8, -7, 40}, {465, 8, -6, 40}// 1312	1313	1314	
			, {465, 8, -4, 40}, {463, 8, -3, 40}, {464, 8, 1, 40}// 1316	1317	1318	
			, {465, 8, 2, 40}, {465, 8, 3, 40}, {465, 8, 5, 40}// 1319	1320	1322	
			, {463, 8, 6, 40}, {474, 8, 7, 40}, {483, 9, -7, 40}// 1323	1324	1325	
			, {483, 9, -6, 40}, {483, 9, -5, 40}, {483, 9, -4, 40}// 1326	1327	1328	
			, {483, 9, 2, 40}, {483, 9, 3, 40}, {474, 9, 4, 40}// 1329	1330	1331	
			, {483, 9, 5, 40}, {483, 9, 6, 40}, {491, 7, -3, 60}// 1332	1333	1334	
			, {491, 7, -2, 60}, {491, 7, -1, 60}, {491, 7, 0, 60}// 1335	1336	1337	
			, {491, 7, 1, 60}, {489, 7, 5, 60}, {490, 7, 6, 60}// 1338	1339	1340	
			, {481, 7, 7, 60}, {491, 8, -7, 60}, {491, 8, -6, 60}// 1341	1342	1343	
			, {491, 8, -5, 60}, {491, 8, -4, 60}, {474, 8, -3, 60}// 1344	1345	1346	
			, {474, 8, 1, 60}, {491, 8, 2, 60}, {491, 8, 3, 60}// 1347	1348	1349	
			, {491, 8, 4, 60}, {488, 8, 5, 60}, {474, 8, 6, 60}// 1350	1351	1352	
			, {1849, 7, 2, 35}, {1849, 7, 3, 30}, {1848, 7, 2, 30}// 1353	1354	1355	
			, {1849, 7, 4, 25}, {1848, 7, 3, 25}, {1848, 7, 2, 25}// 1356	1357	1358	
					};

 
            
		public override BaseAddonDeed Deed
		{
			get
			{
				return new MageFortress1AddonDeed();
			}
		}

		[ Constructable ]
		public MageFortress1Addon()
		{

            for (int i = 0; i < m_AddOnSimpleComponents.Length / 4; i++)
                AddComponent( new AddonComponent( m_AddOnSimpleComponents[i,0] ), m_AddOnSimpleComponents[i,1], m_AddOnSimpleComponents[i,2], m_AddOnSimpleComponents[i,3] );


			AddComplexComponent( (BaseAddon) this, 467, 6, -8, 20, 0, 0, "", 1);// 42
			AddComplexComponent( (BaseAddon) this, 467, -5, -8, 40, 0, 0, "", 1);// 45
			AddComplexComponent( (BaseAddon) this, 467, -3, -8, 40, 0, 0, "", 1);// 47
			AddComplexComponent( (BaseAddon) this, 467, 5, -8, 40, 0, 0, "", 1);// 55
			AddComplexComponent( (BaseAddon) this, 468, -7, 4, 20, 0, 0, "", 1);// 889
			AddComplexComponent( (BaseAddon) this, 468, -6, -1, 20, 0, 0, "", 1);// 895
			AddComplexComponent( (BaseAddon) this, 468, -6, 0, 20, 0, 0, "", 1);// 896
			AddComplexComponent( (BaseAddon) this, 468, -7, -5, 40, 0, 0, "", 1);// 967
			AddComplexComponent( (BaseAddon) this, 468, -7, 4, 40, 0, 0, "", 1);// 973
			AddComplexComponent( (BaseAddon) this, 468, -6, -1, 40, 0, 0, "", 1);// 979
			AddComplexComponent( (BaseAddon) this, 468, -6, 0, 40, 0, 0, "", 1);// 980
			AddComplexComponent( (BaseAddon) this, 467, 0, 4, 40, 0, 0, "", 1);// 1002
			AddComplexComponent( (BaseAddon) this, 467, 2, 4, 40, 0, 0, "", 1);// 1006
			AddComplexComponent( (BaseAddon) this, 467, 7, -8, 40, 0, 0, "", 1);// 1116
			AddComplexComponent( (BaseAddon) this, 468, 7, -1, 20, 0, 0, "", 1);// 1274
			AddComplexComponent( (BaseAddon) this, 468, 7, 0, 20, 0, 0, "", 1);// 1275
			AddComplexComponent( (BaseAddon) this, 468, 7, -1, 40, 0, 0, "", 1);// 1307
			AddComplexComponent( (BaseAddon) this, 468, 7, 0, 40, 0, 0, "", 1);// 1308
			AddComplexComponent( (BaseAddon) this, 468, 8, -5, 40, 0, 0, "", 1);// 1315
			AddComplexComponent( (BaseAddon) this, 468, 8, 4, 40, 0, 0, "", 1);// 1321

		}

		public MageFortress1Addon( Serial serial ) : base( serial )
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

	public class MageFortress1AddonDeed : BaseAddonDeed
	{
		public override BaseAddon Addon
		{
			get
			{
				return new MageFortress1Addon();
			}
		}

		[Constructable]
		public MageFortress1AddonDeed()
		{
			Name = "MageFortress1";
		}

		public MageFortress1AddonDeed( Serial serial ) : base( serial )
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