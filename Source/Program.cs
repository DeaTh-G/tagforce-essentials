using DiscUtils.Iso9660;
using PleOps.XdeltaSharp.Decoder;
using System.Security.Cryptography;

string HashEuropean = "71-9C-99-47-80-32-A4-21-0A-E8-77-83-20-61-E9-FD";
string HashAmerican = "9C-84-D0-0F-5A-4C-19-C3-8C-38-B4-5A-C1-BE-3C-FF";

if (args.Length < 1)
{
    Console.WriteLine("Usage: tagforce-essentials.exe <path_to_iso>");
    Environment.Exit(0);
}

using (var stream = File.OpenRead(args[0]))
{
    if (Directory.Exists("PSP"))
        Directory.Delete("PSP", true);

    bool isEuropean = false;

    var hash = VerifyFileIntegrity(stream);
    if (hash == HashEuropean)
        isEuropean = true;

    ExtractFilesFromIso(stream, isEuropean);
}

string VerifyFileIntegrity(FileStream? stream)
{
    if (stream == null)
        return "";

    using (var md5 = MD5.Create())
    {
        var hash = BitConverter.ToString(md5.ComputeHash(stream));
        if (hash == HashEuropean || hash == HashAmerican)
            return hash;
    }

    return "";
}

void ExtractFilesFromIso(FileStream? isoStream, bool isEuropean)
{
    List<string> fileList = new List<string>()
    {
        @"card\cardh_e.cip",
        @"card\cardh_f.cip", // Doesn't exist in NA version of the game
        @"card\cardh_g.cip", // Doesn't exist in NA version of the game
        @"card\cardh_i.cip", // Doesn't exist in NA version of the game
        @"card\cardh_s.cip", // Doesn't exist in NA version of the game
        @"card\cardm_e.cip",
        @"card\cardm_f.cip", // Doesn't exist in NA version of the game
        @"card\cardm_g.cip", // Doesn't exist in NA version of the game
        @"card\cardm_i.cip", // Doesn't exist in NA version of the game
        @"card\cardm_s.cip", // Doesn't exist in NA version of the game
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
        @"duel\start\start_s.ehp", // Doesn't exist in NA version of the game
        @"duel\start\start_e.ehp", // Doesn't exist in NA version of the game
        @"duel\start\start_f.ehp", // Doesn't exist in NA version of the game
        @"duel\start\start_g.ehp", // Doesn't exist in NA version of the game
        @"duel\start\start_i.ehp", // Doesn't exist in NA version of the game
        @"duel\start\start_j.ehp", // Doesn't exist in NA version of the game
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

    using (var reader = new CDReader(isoStream, true))
    {
        foreach (var fileName in fileList)
        {
            string deltaPatchName = Path.ChangeExtension($@"XDelta\{fileName}", ".xdelta");
            string outFileName = $@"PSP\MODS\TAGFORCE\{fileName}";

            ApplyDeltaPatch(reader, $@"PSP_GAME\USRDIR\{fileName}", deltaPatchName, outFileName);
        }

        Console.WriteLine("\nPatching has finished. Enjoy!");
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