using DiscUtils.Iso9660;
using PleOps.XdeltaSharp.Decoder;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

Dictionary<string, string> Hashes = new Dictionary<string, string>()
{
    { "71-9C-99-47-80-32-A4-21-0A-E8-77-83-20-61-E9-FD", "Yu-Gi-Oh! GX: Tag Force (ULES-00600)" },              // Tag Force PAL
    { "9C-84-D0-0F-5A-4C-19-C3-8C-38-B4-5A-C1-BE-3C-FF", "Yu-Gi-Oh! GX: Tag Force (ULUS-10136)" },              // Tag Force NTSC
    { "81-CB-1D-EE-06-D3-27-8B-26-FE-4B-F5-74-BC-2E-36", "Yu-Gi-Oh! GX: Tag Force 2 (ULES-00925 (v1.01))" },    // Tag Force 2 (v1.01) PAL
    { "7B-1C-B3-6D-BF-2B-96-B3-8B-14-B3-FA-44-B2-FA-A7", "Yu-Gi-Oh! GX: Tag Force 2 (ULES-00925 (v2.00))" },    // Tag Force 2 (v2.00) PAL
    { "D0-3F-5A-02-AD-2D-2F-EF-16-A4-21-86-E9-51-D8-6E", "Yu-Gi-Oh! GX: Tag Force 2 (ULUS-10302)" },            // Tag Force 2 NTSC
    // { "XX-XX-XX-XX-XX-XX-XX-XX-XX-XX-XX-XX-XX-XX-XX-XX", "Yu-Gi-Oh! GX: Tag Force 3 (ULES-01183)" },            // Tag Force 3 PAL
};

List<string> TagForce1FileList = new()
{
    @"card\cardh_e.cip",
    @"card\cardh_f.cip", // Doesn't exist in the NA version of the game
    @"card\cardh_g.cip", // Doesn't exist in the NA version of the game
    @"card\cardh_i.cip", // Doesn't exist in the NA version of the game
    @"card\cardh_s.cip", // Doesn't exist in the NA version of the game
    @"card\cardm_e.cip",
    @"card\cardm_f.cip", // Doesn't exist in the NA version of the game
    @"card\cardm_g.cip", // Doesn't exist in the NA version of the game
    @"card\cardm_i.cip", // Doesn't exist in the NA version of the game
    @"card\cardm_s.cip", // Doesn't exist in the NA version of the game
    @"deck\all_e.ehp",
    @"deck\all_f.ehp",
    @"deck\all_g.ehp",
    @"deck\all_i.ehp",
    @"deck\all_s.ehp",
    @"duel\bg\fmagic0000.ehp",
    @"duel\bg\fmagic4336.ehp",
    @"duel\bg\fmagic4337.ehp",
    @"duel\bg\fmagic4338.ehp",
    @"duel\bg\fmagic4339.ehp",
    @"duel\bg\fmagic4340.ehp",
    @"duel\bg\fmagic4341.ehp",
    @"duel\bg\fmagic4899.ehp",
    @"duel\bg\fmagic4932.ehp",
    @"duel\bg\fmagic4933.ehp",
    @"duel\bg\fmagic4934.ehp",
    @"duel\bg\fmagic4935.ehp",
    @"duel\bg\fmagic4936.ehp",
    @"duel\bg\fmagic4937.ehp",
    @"duel\bg\fmagic5182.ehp",
    @"duel\bg\fmagic5187.ehp",
    @"duel\bg\fmagic5276.ehp",
    @"duel\bg\fmagic5329.ehp",
    @"duel\bg\fmagic5387.ehp",
    @"duel\bg\fmagic5533.ehp",
    @"duel\bg\fmagic5788.ehp",
    @"duel\bg\fmagic5791.ehp",
    @"duel\bg\fmagic5982.ehp",
    @"duel\bg\fmagic6207.ehp",
    @"duel\bg\fmagic6271.ehp",
    @"duel\bg\fmagic6399.ehp",
    @"duel\bg\fmagic6642.ehp",
    @"duel\bg\fmagic6668.ehp",
    @"duel\bg\fmagic6758.ehp",
    @"duel\bg\fmagic6759.ehp",
    @"duel\bg\fmagic6775.ehp",
    @"duel\bg\fmagic6823.ehp",
    @"duel\cutin_da_faces\da_boy_B01.gim",
    @"duel\cutin_da_faces\da_boy_B02.gim",
    @"duel\cutin_da_faces\da_boy_B03.gim",
    @"duel\cutin_da_faces\da_boy_B04.gim",
    @"duel\cutin_da_faces\da_boy_B05.gim",
    @"duel\cutin_da_faces\da_boy_B06.gim",
    @"duel\cutin_da_faces\da_boy_B07.gim",
    @"duel\cutin_da_faces\da_boy_B08.gim",
    @"duel\cutin_da_faces\da_boy_B09.gim",
    @"duel\cutin_da_faces\da_boy_B10.gim",
    @"duel\cutin_da_faces\da_boy_R01.gim",
    @"duel\cutin_da_faces\da_boy_R02.gim",
    @"duel\cutin_da_faces\da_boy_R03.gim",
    @"duel\cutin_da_faces\da_boy_R04.gim",
    @"duel\cutin_da_faces\da_boy_R05.gim",
    @"duel\cutin_da_faces\da_boy_R06.gim",
    @"duel\cutin_da_faces\da_boy_R07.gim",
    @"duel\cutin_da_faces\da_boy_R08.gim",
    @"duel\cutin_da_faces\da_boy_R09.gim",
    @"duel\cutin_da_faces\da_boy_R10.gim",
    @"duel\cutin_da_faces\da_boy_Y01.gim",
    @"duel\cutin_da_faces\da_boy_Y02.gim",
    @"duel\cutin_da_faces\da_boy_Y03.gim",
    @"duel\cutin_da_faces\da_boy_Y04.gim",
    @"duel\cutin_da_faces\da_boy_Y05.gim",
    @"duel\cutin_da_faces\da_boy_Y06.gim",
    @"duel\cutin_da_faces\da_boy_Y07.gim",
    @"duel\cutin_da_faces\da_boy_Y08.gim",
    @"duel\cutin_da_faces\da_boy_Y09.gim",
    @"duel\cutin_da_faces\da_boy_Y10.gim",
    @"duel\cutin_da_faces\da_girl01.gim",
    @"duel\cutin_da_faces\da_girl02.gim",
    @"duel\cutin_da_faces\da_girl03.gim",
    @"duel\cutin_da_faces\da_girl04.gim",
    @"duel\cutin_da_faces\da_girl05.gim",
    @"duel\cutin_da_faces\da_girl06.gim",
    @"duel\cutin_da_faces\da_girl07.gim",
    @"duel\cutin_da_faces\da_girl08.gim",
    @"duel\cutin_da_faces\da_girl09.gim",
    @"duel\cutin_da_faces\da_girl10.gim",
    @"duel\cutin_da_faces\da_teache01.gim",
    @"duel\result\result_e.ehp",
    @"duel\result\result_f.ehp",
    @"duel\result\result_g.ehp",
    @"duel\result\result_i.ehp",
    @"duel\result\result_j.ehp",
    @"duel\result\result_s.ehp",
    @"duel\start\start_all.ehp",
    @"duel\start\start_s.ehp", // Doesn't exist in the NA version of the game
    @"duel\start\start_e.ehp", // Doesn't exist in the NA version of the game
    @"duel\start\start_f.ehp", // Doesn't exist in the NA version of the game
    @"duel\start\start_g.ehp", // Doesn't exist in the NA version of the game
    @"duel\start\start_i.ehp", // Doesn't exist in the NA version of the game
    @"duel\start\start_j.ehp", // Doesn't exist in the NA version of the game
    @"duel\basic_be.ehp",
    @"duel\basic_bf.ehp",
    @"duel\basic_bg.ehp",
    @"duel\basic_bi.ehp",
    @"duel\basic_bs.ehp",
    @"duel\basic_ea.ehp",
    @"duel\basic_eb.ehp",
    @"duel\basic_fe.ehp",
    @"duel\basic_ff.ehp",
    @"duel\basic_fg.ehp",
    @"duel\basic_fi.ehp",
    @"duel\basic_fs.ehp",
    @"duel\basic_ge.ehp",
    @"duel\basic_gf.ehp",
    @"duel\basic_gg.ehp",
    @"duel\basic_gi.ehp",
    @"duel\basic_gs.ehp",
    @"duel\basic_ie.ehp",
    @"duel\basic_if.ehp",
    @"duel\basic_ig.ehp",
    @"duel\basic_ii.ehp",
    @"duel\basic_is.ehp",
    @"duel\basic_se.ehp",
    @"duel\basic_sf.ehp",
    @"duel\basic_sg.ehp",
    @"duel\basic_si.ehp",
    @"duel\basic_ss.ehp",
    @"duel\basic_ue.ehp",
    @"duel\basic_uf.ehp",
    @"duel\basic_ug.ehp",
    @"duel\basic_ui.ehp",
    @"duel\basic_us.ehp",
    @"duel\cutin_abdos01.ehp",
    @"duel\cutin_amunael01.ehp",
    @"duel\cutin_aska01.ehp",
    @"duel\cutin_ayukawa01.ehp",
    @"duel\cutin_bmgirl01.ehp",
    @"duel\cutin_boy01.ehp",
    @"duel\cutin_chousaku01.ehp",
    @"duel\cutin_cmn.ehp",
    @"duel\cutin_common.ehp",
    @"duel\cutin_da_boy_b01.ehp",
    @"duel\cutin_da_boy_b02.ehp",
    @"duel\cutin_da_boy_b03.ehp",
    @"duel\cutin_da_boy_b04.ehp",
    @"duel\cutin_da_boy_b05.ehp",
    @"duel\cutin_da_boy_r01.ehp",
    @"duel\cutin_da_boy_r02.ehp",
    @"duel\cutin_da_boy_r03.ehp",
    @"duel\cutin_da_boy_r04.ehp",
    @"duel\cutin_da_boy_r05.ehp",
    @"duel\cutin_da_boy_y01.ehp",
    @"duel\cutin_da_boy_y02.ehp",
    @"duel\cutin_da_boy_y03.ehp",
    @"duel\cutin_da_boy_y04.ehp",
    @"duel\cutin_da_boy_y05.ehp",
    @"duel\cutin_da_girl01.ehp",
    @"duel\cutin_da_girl02.ehp",
    @"duel\cutin_da_girl03.ehp",
    @"duel\cutin_da_girl04.ehp",
    @"duel\cutin_da_girl05.ehp",
    @"duel\cutin_da_teacher01.ehp",
    @"duel\cutin_daitokuji01.ehp",
    @"duel\cutin_fubuki_drk01.ehp",
    @"duel\cutin_fubuki01.ehp",
    @"duel\cutin_hayato01.ehp",
    @"duel\cutin_junko01.ehp",
    @"duel\cutin_jyudai01.ehp",
    @"duel\cutin_kagemaru01.ehp",
    @"duel\cutin_kagemaru02_a.ehp",
    @"duel\cutin_kagemaru03msg.ehp",
    @"duel\cutin_kamula01.ehp",
    @"duel\cutin_kamura01.ehp",
    @"duel\cutin_kuronosu01.ehp",
    @"duel\cutin_meikyu_k01.ehp",
    @"duel\cutin_meikyu_m01.ehp",
    @"duel\cutin_misawa01.ehp",
    @"duel\cutin_mokeo01.ehp",
    @"duel\cutin_momoe01.ehp",
    @"duel\cutin_player01.ehp",
    @"duel\cutin_psychoshocker01.ehp",
    @"duel\cutin_rei01.ehp",
    @"duel\cutin_rei02.ehp",
    @"duel\cutin_ryo01.ehp",
    @"duel\cutin_sal01.ehp",
    @"duel\cutin_sala01.ehp",
    @"duel\cutin_seiko01.ehp",
    @"duel\cutin_shou01.ehp",
    @"duel\cutin_shouji01.ehp",
    @"duel\cutin_taizan01.ehp",
    @"duel\cutin_tania01.ehp",
    @"duel\cutin_thunder_blk01.ehp",
    @"duel\cutin_thunder01.ehp",
    @"duel\cutin_titan01.ehp",
    @"duel\cutin_tome01.ehp",
    @"duel\cutin_zaloog01_a.ehp",
    @"duel\zakov50.ehp",
    @"duel\zakov51.ehp",
    @"duel\zakov52.ehp",
    @"duel\zakov53.ehp",
    @"duel\zakov54.ehp",
    @"duel\zakov55.ehp",
    @"duel\zakov56.ehp",
    @"duel\zakov57.ehp",
    @"duel\zakov58.ehp",
    @"duel\zakov59.ehp",
    @"duel\zakov60.ehp",
    @"duel\zakov61.ehp",
    @"duel\zakov62.ehp",
    @"duel\zakov63.ehp",
    @"duel\zakov64.ehp",
    @"duel\zakov65.ehp",
    @"duel\zakov66.ehp",
    @"duel\zakov67.ehp",
    @"duel\zakov68.ehp",
    @"duel\zakov69.ehp",
    @"duel\zakov70.ehp",
    @"duel\zakov71.ehp",
    @"duel\zakov72.ehp",
    @"duel\zakov73.ehp",
    @"duel\zakov74.ehp",
    @"duel\zakov75.ehp",
    @"duel\zakov76.ehp",
    @"duel\zakov77.ehp",
    @"duel\zakov78.ehp",
    @"duel\zakov79.ehp",
    @"duel\zakov80.ehp",
    @"duel\zakov81.ehp",
    @"duel\zakov82.ehp",
    @"movie\cyb_attack_a.pmf",
    @"movie\cyb_summon_a.pmf",
    @"movie\ouijaboard_final.pmf",
    @"movie\rampart_attack_a.pmf",
    @"movie\rampart_summon_a.pmf"
};

List<string> TagForce2FileList = new()
{
    @"deck\all_a.ehp",
    @"deck\all_e.ehp",
    @"deck\all_f.ehp",
    @"deck\all_g.ehp",
    @"deck\all_i.ehp",
    @"deck\all_s.ehp",
    @"duel\basic_be.ehp", // Doesn't exist in the NA version of the game
    @"duel\basic_bf.ehp", // Doesn't exist in the NA version of the game
    @"duel\basic_bg.ehp", // Doesn't exist in the NA version of the game
    @"duel\basic_bi.ehp", // Doesn't exist in the NA version of the game
    @"duel\basic_bs.ehp", // Doesn't exist in the NA version of the game
    @"duel\basic_ue.ehp", // Doesn't exist in the PAL version of the game
    @"card\card8_a.cip",
    @"card\cardh_e.cip",
    @"card\cardh_f.cip",
    @"card\cardh_g.cip",
    @"card\cardh_i.cip",
    @"card\cardh_s.cip",
    @"card\cardj_a.cip",
    @"card\cardm_e.cip",
    @"card\cardm_f.cip",
    @"card\cardm_g.cip",
    @"card\cardm_i.cip",
    @"card\cardm_s.cip",
    @"duel\cutin_ammon01.ehp",
    @"duel\cutin_aska_w1.ehp",
    @"duel\cutin_aska01.ehp",
    @"duel\cutin_ayukawa01.ehp",
    @"duel\cutin_bmgirl01.ehp",
    @"duel\cutin_boy01.ehp",
    @"duel\cutin_chousaku01.ehp",
    @"duel\cutin_cmn.ehp",
    @"duel\cutin_cobra01.ehp",
    @"duel\cutin_common.ehp",
    @"duel\cutin_da_boy_b01.ehp",
    @"duel\cutin_da_boy_b02.ehp",
    @"duel\cutin_da_boy_b03.ehp",
    @"duel\cutin_da_boy_b04.ehp",
    @"duel\cutin_da_boy_b05.ehp",
    @"duel\cutin_da_boy_r01.ehp",
    @"duel\cutin_da_boy_r02.ehp",
    @"duel\cutin_da_boy_r03.ehp",
    @"duel\cutin_da_boy_r04.ehp",
    @"duel\cutin_da_boy_r05.ehp",
    @"duel\cutin_da_boy_y01.ehp",
    @"duel\cutin_da_boy_y02.ehp",
    @"duel\cutin_da_boy_y03.ehp",
    @"duel\cutin_da_boy_y04.ehp",
    @"duel\cutin_da_boy_y05.ehp",
    @"duel\cutin_da_girl_chika.ehp",
    @"duel\cutin_da_girl_reika.ehp",
    @"duel\cutin_da_girl_sachiko.ehp",
    @"duel\cutin_da_girl_sakura.ehp",
    @"duel\cutin_da_girl_yukino.ehp",
    @"duel\cutin_da_girl_yuma.ehp",
    @"duel\cutin_da_girl01.ehp",
    @"duel\cutin_da_girl02.ehp",
    @"duel\cutin_da_girl03.ehp",
    @"duel\cutin_da_girl04.ehp",
    @"duel\cutin_da_girl05.ehp",
    @"duel\cutin_da_teacher01.ehp",
    @"duel\cutin_ed01.ehp",
    @"duel\cutin_fubuki_drk01.ehp",
    @"duel\cutin_fubuki01.ehp",
    @"duel\cutin_fubuki02.ehp",
    @"duel\cutin_jim01.ehp",
    @"duel\cutin_junko01.ehp",
    @"duel\cutin_jyudai01.ehp",
    @"duel\cutin_kenzan01.ehp",
    @"duel\cutin_kuronosu01.ehp",
    @"duel\cutin_meikyu_k01.ehp",
    @"duel\cutin_meikyu_m01.ehp",
    @"duel\cutin_misawa_w1.ehp",
    @"duel\cutin_misawa01.ehp",
    @"duel\cutin_mizuchi01.ehp",
    @"duel\cutin_momoe01.ehp",
    @"duel\cutin_napoleon01.ehp",
    @"duel\cutin_obrien01.ehp",
    @"duel\cutin_player01.ehp",
    @"duel\cutin_psychoshocker01.ehp",
    @"duel\cutin_rei01.ehp",
    @"duel\cutin_rei02.ehp",
    @"duel\cutin_rei03.ehp",
    @"duel\cutin_rei04.ehp",
    @"duel\cutin_ryo01.ehp",
    @"duel\cutin_ryo02.ehp",
    @"duel\cutin_saioh01.ehp",
    @"duel\cutin_saioh02.ehp",
    @"duel\cutin_sala01.ehp",
    @"duel\cutin_seiko01.ehp",
    @"duel\cutin_shou01.ehp",
    @"duel\cutin_shou02.ehp",
    @"duel\cutin_shouji01.ehp",
    @"duel\cutin_taizan01.ehp",
    @"duel\cutin_thunder_blk01.ehp",
    @"duel\cutin_thunder_w1.ehp",
    @"duel\cutin_thunder01.ehp",
    @"duel\cutin_titan01.ehp",
    @"duel\cutin_tome01.ehp",
    @"duel\cutin_yohan01.ehp",
    @"movie\cyb_attack_a.pmf",
    @"movie\cyb_summon_a.pmf",
    @"duel\cutin_da_faces\da_boy_B01.gim",
    @"duel\cutin_da_faces\da_boy_B02.gim",
    @"duel\cutin_da_faces\da_boy_B03.gim",
    @"duel\cutin_da_faces\da_boy_B04.gim",
    @"duel\cutin_da_faces\da_boy_B05.gim",
    @"duel\cutin_da_faces\da_boy_B06.gim",
    @"duel\cutin_da_faces\da_boy_B07.gim",
    @"duel\cutin_da_faces\da_boy_B08.gim",
    @"duel\cutin_da_faces\da_boy_B09.gim",
    @"duel\cutin_da_faces\da_boy_B10.gim",
    @"duel\cutin_da_faces\da_boy_R01.gim",
    @"duel\cutin_da_faces\da_boy_R02.gim",
    @"duel\cutin_da_faces\da_boy_R03.gim",
    @"duel\cutin_da_faces\da_boy_R04.gim",
    @"duel\cutin_da_faces\da_boy_R05.gim",
    @"duel\cutin_da_faces\da_boy_R06.gim",
    @"duel\cutin_da_faces\da_boy_R07.gim",
    @"duel\cutin_da_faces\da_boy_R08.gim",
    @"duel\cutin_da_faces\da_boy_R09.gim",
    @"duel\cutin_da_faces\da_boy_R10.gim",
    @"duel\cutin_da_faces\da_boy_Y01.gim",
    @"duel\cutin_da_faces\da_boy_Y02.gim",
    @"duel\cutin_da_faces\da_boy_Y03.gim",
    @"duel\cutin_da_faces\da_boy_Y04.gim",
    @"duel\cutin_da_faces\da_boy_Y05.gim",
    @"duel\cutin_da_faces\da_boy_Y06.gim",
    @"duel\cutin_da_faces\da_boy_Y07.gim",
    @"duel\cutin_da_faces\da_boy_Y08.gim",
    @"duel\cutin_da_faces\da_boy_Y09.gim",
    @"duel\cutin_da_faces\da_boy_Y10.gim",
    @"duel\cutin_da_faces\da_girl_chika.gim",
    @"duel\cutin_da_faces\da_girl01.gim",
    @"duel\cutin_da_faces\da_girl02.gim",
    @"duel\cutin_da_faces\da_girl03.gim",
    @"duel\cutin_da_faces\da_girl04.gim",
    @"duel\cutin_da_faces\da_girl05.gim",
    @"duel\cutin_da_faces\da_girl06.gim",
    @"duel\cutin_da_faces\da_girl07.gim",
    @"duel\cutin_da_faces\da_girl08.gim",
    @"duel\cutin_da_faces\da_girl09.gim",
    @"duel\cutin_da_faces\da_girl10.gim",
    @"duel\cutin_da_faces\da_teache01.gim",
    @"duel\bg\fmagic0000.ehp",
    @"duel\bg\fmagic05.ehp",
    @"duel\bg\fmagic3720.ehp",
    @"duel\bg\fmagic3723.ehp",
    @"duel\bg\fmagic3733.ehp",
    @"duel\bg\fmagic4336.ehp",
    @"duel\bg\fmagic4337.ehp",
    @"duel\bg\fmagic4338.ehp",
    @"duel\bg\fmagic4339.ehp",
    @"duel\bg\fmagic4340.ehp",
    @"duel\bg\fmagic4341.ehp",
    @"duel\bg\fmagic4899.ehp",
    @"duel\bg\fmagic4932.ehp",
    @"duel\bg\fmagic4933.ehp",
    @"duel\bg\fmagic4934.ehp",
    @"duel\bg\fmagic4935.ehp",
    @"duel\bg\fmagic4936.ehp",
    @"duel\bg\fmagic4937.ehp",
    @"duel\bg\fmagic5182.ehp",
    @"duel\bg\fmagic5187.ehp",
    @"duel\bg\fmagic5276.ehp",
    @"duel\bg\fmagic5329.ehp",
    @"duel\bg\fmagic5387.ehp",
    @"duel\bg\fmagic5533.ehp",
    @"duel\bg\fmagic5788.ehp",
    @"duel\bg\fmagic5791.ehp",
    @"duel\bg\fmagic5982.ehp",
    @"duel\bg\fmagic6207.ehp",
    @"duel\bg\fmagic6271.ehp",
    @"duel\bg\fmagic6399.ehp",
    @"duel\bg\fmagic6642.ehp",
    @"duel\bg\fmagic6668.ehp",
    @"duel\bg\fmagic6758.ehp",
    @"duel\bg\fmagic6759.ehp",
    @"duel\bg\fmagic6775.ehp",
    @"duel\bg\fmagic6823.ehp",
    @"duel\bg\fmagic7003.ehp",
    @"duel\bg\fmagic7004.ehp",
    @"duel\bg\fmagic7079.ehp",
    @"duel\bg\fmagic7129.ehp",
    @"duel\bg\fmagic7164.ehp",
    @"duel\bup\mini_bup_ammon_0.ehp",
    @"duel\bup\mini_bup_asuka_0.ehp",
    @"duel\bup\mini_bup_asuka_1.ehp",
    @"duel\bup\mini_bup_ayukawa_0.ehp",
    @"duel\bup\mini_bup_boy_0.ehp",
    @"duel\bup\mini_bup_buramaji_girl_0.ehp",
    @"duel\bup\mini_bup_chosaku_0.ehp",
    @"duel\bup\mini_bup_cobra_0.ehp",
    @"duel\bup\mini_bup_cronos_0.ehp",
    @"duel\bup\mini_bup_edo_0.ehp",
    @"duel\bup\mini_bup_fubuki_0.ehp",
    @"duel\bup\mini_bup_fubuki_1.ehp",
    @"duel\bup\mini_bup_fubuki_2.ehp",
    @"duel\bup\mini_bup_jim_0.ehp",
    @"duel\bup\mini_bup_jinzo_0.ehp",
    @"duel\bup\mini_bup_johann_0.ehp",
    @"duel\bup\mini_bup_judai_0.ehp",
    @"duel\bup\mini_bup_junko_0.ehp",
    @"duel\bup\mini_bup_kenzan_0.ehp",
    @"duel\bup\mini_bup_manjoume_0.ehp",
    @"duel\bup\mini_bup_manjoume_1.ehp",
    @"duel\bup\mini_bup_manjoume_2.ehp",
    @"duel\bup\mini_bup_meikyu_old_0.ehp",
    @"duel\bup\mini_bup_meikyu_young_0.ehp",
    @"duel\bup\mini_bup_mg_enemy_0.ehp",
    @"duel\bup\mini_bup_mg_enemy_1.ehp",
    @"duel\bup\mini_bup_mg_enemy_2.ehp",
    @"duel\bup\mini_bup_mg_enemy_3.ehp",
    @"duel\bup\mini_bup_mg_enemy_4.ehp",
    @"duel\bup\mini_bup_mg_enemy_5.ehp",
    @"duel\bup\mini_bup_mg_enemy_6.ehp",
    @"duel\bup\mini_bup_mg_enemy_7.ehp",
    @"duel\bup\mini_bup_mg_enemy_8.ehp",
    @"duel\bup\mini_bup_mg_enemy_9.ehp",
    @"duel\bup\mini_bup_misawa_0.ehp",
    @"duel\bup\mini_bup_misawa_1.ehp",
    @"duel\bup\mini_bup_mizuchi_0.ehp",
    @"duel\bup\mini_bup_momoe_0.ehp",
    @"duel\bup\mini_bup_motegi_0.ehp",
    @"duel\bup\mini_bup_napoleon_0.ehp",
    @"duel\bup\mini_bup_obrien_0.ehp",
    @"duel\bup\mini_bup_player_0.ehp",
    @"duel\bup\mini_bup_player_1.ehp",
    @"duel\bup\mini_bup_player_2.ehp",
    @"duel\bup\mini_bup_player_3.ehp",
    @"duel\bup\mini_bup_player_4.ehp",
    @"duel\bup\mini_bup_rei_0.ehp",
    @"duel\bup\mini_bup_rei_1.ehp",
    @"duel\bup\mini_bup_rei_2.ehp",
    @"duel\bup\mini_bup_rei_3.ehp",
    @"duel\bup\mini_bup_ryo_0.ehp",
    @"duel\bup\mini_bup_ryo_1.ehp",
    @"duel\bup\mini_bup_saioh_0.ehp",
    @"duel\bup\mini_bup_saioh_1.ehp",
    @"duel\bup\mini_bup_sal_0.ehp",
    @"duel\bup\mini_bup_sarah_0.ehp",
    @"duel\bup\mini_bup_seiko_0.ehp",
    @"duel\bup\mini_bup_syou_0.ehp",
    @"duel\bup\mini_bup_syou_1.ehp",
    @"duel\bup\mini_bup_syouji_0.ehp",
    @"duel\bup\mini_bup_taizan_0.ehp",
    @"duel\bup\mini_bup_titan_0.ehp",
    @"duel\bup\mini_bup_titan_1.ehp",
    @"duel\bup\mini_bup_tome_0.ehp",
    @"duel\bup\mini_bup_tome_1.ehp",
    @"duel\bup\mini_bup_vj_inoso.ehp",
    @"duel\bup\mini_bup_vj_mokuma.ehp",
    @"duel\bup\mini_bup_vj_sanzyudai.ehp",
    @"duel\bup\mini_bup_vj_senzyome.ehp",
    @"duel\bup\mini_bup_vj_sironosu.ehp",
    @"duel\bup\mini_bup_vj_umiuma.ehp",
    @"duel\bup\mini_bup_zako.ehp",
    @"movie\ouijaboard_final.pmf",
    @"snd\psp_snddat.bin",
    @"movie\rampart_attack_a.pmf",
    @"movie\rampart_summon_a.pmf",
    @"duel\result\result_e.ehp",
    @"duel\result\result_f.ehp",
    @"duel\result\result_g.ehp",
    @"duel\result\result_i.ehp",
    @"duel\result\result_s.ehp",
    @"duel\start\start_e.ehp",
    @"duel\start\start_f.ehp",
    @"duel\start\start_g.ehp",
    @"duel\start\start_i.ehp",
    @"duel\start\start_s.ehp",
    @"duel\zakov50.ehp",
    @"duel\zakov51.ehp",
    @"duel\zakov52.ehp",
    @"duel\zakov53.ehp",
    @"duel\zakov54.ehp",
    @"duel\zakov55.ehp",
    @"duel\zakov56.ehp",
    @"duel\zakov57.ehp",
    @"duel\zakov58.ehp",
    @"duel\zakov59.ehp",
    @"duel\zakov60.ehp",
    @"duel\zakov61.ehp",
    @"duel\zakov62.ehp",
    @"duel\zakov63.ehp",
    @"duel\zakov64.ehp",
    @"duel\zakov65.ehp",
    @"duel\zakov66.ehp",
    @"duel\zakov67.ehp",
    @"duel\zakov68.ehp",
    @"duel\zakov69.ehp",
    @"duel\zakov70.ehp",
    @"duel\zakov71.ehp",
    @"duel\zakov72.ehp",
    @"duel\zakov73.ehp",
    @"duel\zakov74.ehp",
    @"duel\zakov75.ehp",
    @"duel\zakov76.ehp",
    @"duel\zakov77.ehp",
    @"duel\zakov78.ehp",
    @"duel\zakov79.ehp",
    @"duel\zakov80.ehp",
    @"duel\zakov81.ehp",
    @"duel\zakov82.ehp"
};

if (args.Length < 1)
{
    Console.WriteLine("Usage: tagforce-essentials.exe <path_to_iso>");
    LogSupportedGames();
    Environment.Exit(0);
}

using (var stream = File.OpenRead(args[0]))
{
    if (Directory.Exists("PSP"))
        Directory.Delete("PSP", true);

    var hash = VerifyFileIntegrity(stream);
    if (string.IsNullOrEmpty(hash) || !Hashes.ContainsKey(hash))
    {
        Console.WriteLine($"Incorrect MD5 ({hash.Replace('-', new())}) detected.");
        LogSupportedGames();
        Environment.Exit(0);
    }
    else
    {
        Console.WriteLine($"{Hashes[hash]} game backup detected. Proceeding with patching...");
    }

    ExtractFilesFromIso(stream, hash);
}

void LogSupportedGames()
{
    Console.WriteLine("Please provide a clean backup of one of following supported titles:");
    foreach (var pair in Hashes)
    {
        Console.WriteLine($"{pair.Value} MD5: {pair.Key.Replace('-', new())}");
    }
}

string VerifyFileIntegrity(FileStream? stream)
{
    Console.WriteLine("Verifying integrity of game backup...");

    if (stream == null)
        return "";

    using var md5 = MD5.Create();
    var hash = BitConverter.ToString(md5.ComputeHash(stream));
    if (Hashes.ContainsKey(hash))
        return hash;

    return hash;
}

void ExtractFilesFromIso(FileStream? isoStream, string hash)
{
    using (var reader = new CDReader(isoStream, true))
    {
        List<string> fileList = new();
        string gameName = "";
        switch (hash)
        {
            case "71-9C-99-47-80-32-A4-21-0A-E8-77-83-20-61-E9-FD":
            case "9C-84-D0-0F-5A-4C-19-C3-8C-38-B4-5A-C1-BE-3C-FF":
                gameName = "TAGFORCE";
                fileList = TagForce1FileList;
                break;
            case "81-CB-1D-EE-06-D3-27-8B-26-FE-4B-F5-74-BC-2E-36":
            case "7B-1C-B3-6D-BF-2B-96-B3-8B-14-B3-FA-44-B2-FA-A7":
            case "D0-3F-5A-02-AD-2D-2F-EF-16-A4-21-86-E9-51-D8-6E":
                fileList = TagForce2FileList;
                gameName = "TAGFORCE2";
                break;
            default:
                Console.WriteLine("Could not locate the appropriate list of files to extract from ISO. Exiting...");
                Environment.Exit(0);
                break;
        }

        foreach (var fileName in fileList)
        {
            string gameId = Regex.Match(Hashes[hash], @"\b[A-Z]{4}-\d{5}\b(?:\s*\(v\d+(?:\.\d+)*\))?").Value;
            string deltaPatchName = Path.ChangeExtension($@"{AppDomain.CurrentDomain.BaseDirectory}\XDelta\{gameId}\{fileName}", ".xdelta");
            string outFileName = $@"PSP\MODS\{gameName}\{fileName}";

            ApplyDeltaPatch(reader, $@"PSP_GAME\USRDIR\{fileName}", deltaPatchName, outFileName);
        }

        Console.WriteLine("Patching has finished. Enjoy!");
    }
}

void ApplyDeltaPatch(CDReader reader, string fileName, string deltaPatchName, string outFileName)
{
    if (!reader.FileExists(fileName))
        return;

    using (var fileStream = reader.OpenFile(fileName, FileMode.Open))
    {
        if (!Directory.Exists(Path.GetDirectoryName(outFileName)))
            Directory.CreateDirectory(Path.GetDirectoryName(outFileName));

        using (var outFileStream = File.Create(outFileName))
        {
            if (!Path.Exists(deltaPatchName))
            {
                Console.WriteLine($"Copying original file: {fileName}");
                fileStream.CopyTo(outFileStream);
                return;
            }

            using (var patchFileStream = File.OpenRead(deltaPatchName))
            {
                using var decoder = new Decoder(fileStream, patchFileStream, outFileStream);
                decoder.Run();
                Console.WriteLine($"Applying delta patch to file: {fileName}");
            }
        }
    }
}

