﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Deltin.CustomGameAutomation.Properties;

namespace Deltin.CustomGameAutomation
{
    internal static class Colors
    {
        public static readonly int[] WHITE = new int[] { 191, 191, 191 };
        public static readonly int[] LOADING_BLACK = new int[] { 64, 64, 64 };

        public static readonly int[] CONFIRM = new int[] { 176, 141, 89 };

        public static readonly int[] LOADING_ENTERING_GAME = new int[] { 176, 141, 89 };

        public static readonly int[] LOBBY_START_GAME = new int[] { 150, 127, 96 };
        public static readonly int[] LOBBY_CHANGE = new int[] { 126, 158, 181 };
        public static readonly int[] LOBBY_INVITE_PLAYERS_TO_GROUP_MIN = new int[] { 77, 130, 165 };
        public static readonly int[] LOBBY_INVITE_PLAYERS_TO_GROUP_MAX = new int[] { 95, 145, 180 };

        public static readonly int[] SETTINGS_PRESETS_LOADABLE_PRESET = new int[] { 126, 128, 134 };

        public static readonly int[] DEAD_PLAYER = new int[] { 118, 74, 76 }; // Spectator UI red X
        public static readonly int[] HERO_CHOSEN_BLUE = new int[] { 83, 110, 123 };
        public static readonly int[] HERO_CHOSEN_RED = new int[] { 114, 77, 81 };

        public static readonly int[] MODERATOR_ICON = new int[] { 143, 155, 80 };
        public static readonly int[] SPECTATOR_MODERATOR_ICON = new int[] { 149, 183, 89 };

        public static readonly int[] ENDING_COMMEND_DEFEAT = new int[] { 120, 70, 74 };

        public static readonly int[] SETTINGS_ERROR = new int[] { 151, 119, 81 };
        public static readonly int[] SETTINGS_MODES_ENABLED = new int[] { 125, 127, 135 };

        public static readonly int[] EXIT_TO_DESKTOP = new int[] { 83, 124, 152 };
    }

    internal static class Fades
    {
        public static readonly int SETTINGS_ERROR = 20;
        public static readonly int DEAD_PLAYER = 15;

        public static readonly int LOADING_ENTERING_GAME = 20;

        public static readonly int LOBBY_START_GAME = 30;
        public static readonly int LOBBY_CHANGE = 50;
        public static readonly int LOBBY_INVITE_PLAYERS_TO_GROUP_COMPARE = 15;

        public static readonly int SETTINGS_PRESETS_LOADABLE_PRESET = 30;
        public static readonly int SETTINGS_MODES_ENABLED = 30;

        public static readonly int CONFIRM = 50;

        public static readonly int HEROES_CHOSEN = 15;

        public static readonly int ENDING_COMMEND_DEFEAT = 10;

        public static readonly int EXIT_TO_DESKTOP = 15;
    }

    internal static class Points
    {
        public static readonly Point RESET_POINT = new Point(500, 500);

        public static readonly Point PRE_MAIN_MENU_LOGIN = new Point(419, 473);

        public static readonly Point MAIN_MENU_OVERWATCH_WATERMARK = new Point(53, 68);

        public static readonly Point OPTIONS_APPLY = new Point(400, 500);
        public static readonly Point OPTIONS_BACK = new Point(500, 500);

        public static readonly Point LOADING_ENTERING_GAME = new Point(450, 325);

        public static readonly Point LOBBY_ADD_AI = new Point(835, 182);
        public static readonly Point LOBBY_BACK_TO_LOBBY = new Point(394, 457);
        public static readonly Point LOBBY_CHATBOX = new Point(105, 504);
        public static readonly Point LOBBY_CHAT_TYPE_INDICATOR = new Point(50, 505);
        public static readonly Point LOBBY_GAME_NAME = new Point(209, 165);
        public static readonly Point LOBBY_INVITE_IF_ADD_BUTTON_PRESENT = new Point(778, 180);
        public static readonly Point LOBBY_INVITE_IF_ADD_BUTTON_NOT_PRESENT = new Point(835, 180);
        public static readonly Point LOBBY_JOIN_DROPDOWN = new Point(280, 198);
        public static readonly Point LOBBY_JOIN_EVERYONE = new Point(280, 220);
        public static readonly Point LOBBY_JOIN_FRIENDS = new Point(280, 240);
        public static readonly Point LOBBY_JOIN_INVITE = new Point(280, 260);
        public static readonly Point LOBBY_MOVE_IF_ADD_BUTTON_PRESENT = new Point(661, 180);
        public static readonly Point LOBBY_MOVE_IF_ADD_BUTTON_NOT_PRESENT = new Point(717, 180);
        public static readonly Point LOBBY_SETTINGS_IF_ADD_BUTTON_PRESENT = new Point(716, 180);
        public static readonly Point LOBBY_SETTINGS_IF_ADD_BUTTON_NOT_PRESENT = new Point(774, 180);
        public static readonly Point LOBBY_START_GAME = new Point(451, 458);
        public static readonly Point LOBBY_START_FROM_WAITING_FOR_PLAYERS = new Point(570, 455);
        public static readonly Point LOBBY_START_GAMEMODE = new Point(599, 456);
        public static readonly Point LOBBY_RESTART = new Point(500, 455);
        public static readonly Point LOBBY_SWAP_ALL_IF_ADD_BUTTON_PRESENT = new Point(617, 180);
        public static readonly Point LOBBY_SWAP_ALL_IF_ADD_BUTTON_NOT_PRESENT = new Point(678, 180);
        public static readonly Point LOBBY_MY_PLAYER_ICON = new Point(744, 62);
        public static readonly Point LOBBY_BLUE_NAME = new Point(159, 229);
        public static readonly Point LOBBY_RED_NAME = new Point(458, 230);
        public static readonly Point LOBBY_PAUSED = new Point(441, 268);
        public static readonly Point LOBBY_INVITE_PLAYERS_TO_GROUP = new Point(703, 51);
        public static readonly Point LOBBY_INVITE_PLAYERS_TO_GROUP_COMPARE = new Point(703, 40);

        public static readonly Point EDIT_AI_CONFIRM = new Point(447, 354);

        public static readonly Point INVITE_INVITE = new Point(460, 434);
        public static readonly Point INVITE_BACK = new Point(412, 434);
        public static readonly Point INVITE_VIA_BATTLETAG = new Point(572, 171);
        public static readonly Point INVITE_TEAM_DROPDOWN = new Point(475, 398);
        public static readonly Point INVITE_TEAM_BLUE = new Point(475, 447);
        public static readonly Point INVITE_TEAM_RED = new Point(475, 466);
        public static readonly Point INVITE_TEAM_SPECTATOR = new Point(475, 483);

        public static readonly Point SETTINGS_PRESETS = new Point(103, 183);
        public static readonly Point SETTINGS_LOBBY = new Point(297, 183);
        public static readonly Point SETTINGS_MODES = new Point(494, 178);
        public static readonly Point SETTINGS_MAPS = new Point(103, 300);
        public static readonly Point SETTINGS_HEROES = new Point(351, 311);
        public static readonly Point SETTINGS_ERROR = new Point(522, 320);
        public static readonly Point SETTINGS_BACK = new Point(855, 507);
        public static readonly Point SETTINGS_DISCARD = new Point(436, 318);

        public static readonly Point PRESETS_CONFIRM = new Point(480, 327);

        public static readonly Point SETTINGS_LOBBY_BLUE_MAX_PLAYERS = new Point(500, 269);
        public static readonly Point SETTINGS_LOBBY_RED_MAX_PLAYERS = new Point(500, 290);
        public static readonly Point SETTINGS_LOBBY_FFA_MAX_PLAYERS = new Point(500, 311);
        public static readonly Point SETTINGS_LOBBY_MAX_SPECTATORS = new Point(500, 333);

        public static readonly Point SETTINGS_MAPS_DISABLE_ALL = new Point(640, 125);
        public static readonly Point SETTINGS_MAPS_ENABLE_ALL = new Point(600, 125);

        public static readonly Point SETTINGS_HEROES_GENERAL = new Point(80, 146);
        public static readonly Point SETTINGS_HEROES_ROSTER = new Point(287, 158);

        public static readonly Point SETTINGS_HEROES_SETTINGS_TEAM_DROPDOWN = new Point(572, 126);
        public static readonly Point SETTINGS_HEROES_SETTINGS_TEAM_BLUE = new Point(572, 173);
        public static readonly Point SETTINGS_HEROES_SETTINGS_TEAM_RED = new Point(572, 192);

        public static readonly Point SETTINGS_HEROES_ROSTER_TEAM_DROPDOWN = new Point(492, 127);
        public static readonly Point SETTINGS_HEROES_ROSTER_TEAM_BLUE = new Point(484, 173);
        public static readonly Point SETTINGS_HEROES_ROSTER_TEAM_RED = new Point(484, 193);
        public static readonly Point SETTINGS_HEROES_ROSTER_DISABLE_ALL = new Point(635, 130);
        public static readonly Point SETTINGS_HEROES_ROSTER_ENABLE_ALL = new Point(597, 130);

        public static readonly Point ENDING_COMMEND_DEFEAT = new Point(53, 62);

        public static readonly Point EXIT_TO_DESKTOP = new Point(130, 505);
    }

    internal static class Rectangles
    {
        public static readonly Rectangle ENTIRE_SCREEN = new Rectangle(0, 0, 960, 540);

        public static readonly Rectangle LOBBY_CHATBOX = new Rectangle(50, 461, 169, 26);
        public static readonly Rectangle LOBBY_CAREER_PROFILE = new Rectangle(46, 101, 265, 82);
        public static readonly Rectangle LOBBY_MAP = new Rectangle(52, 153, 139, 56);

        public static readonly Rectangle SETTINGS_PRESET_OPTION = new Rectangle(0, 0, 128, 20);
    }

    internal static class Distances
    {
        public static readonly int LOBBY_SLOT_DISTANCE = 29;
        public static readonly int LOBBY_TEAM_SLOT_DISTANCE = 319; // 322
        public static readonly int LOBBY_SPECTATOR_SLOT_DISTANCE = 13;
        public static readonly int LOBBY_QUEUE_OFFSET = 6; // Did you know that the queue list is 6 pixels higher than the spectator list?
        public static readonly int LOBBY_SLOT_HEIGHT = 26;
        public static readonly int LOBBY_SPECTATOR_SLOT_HEIGHT = 11;

        public static readonly int LOBBY_SLOT_DM_BLUE_X_OFFSET = 17;
        public static readonly int LOBBY_SLOT_DM_RED_X_OFFSET = -17;
        public static readonly int LOBBY_SLOT_DM_Y_OFFSET = -20;
    }

    internal static class Markups
    {
        // Markups for the option menu
        public static readonly DirectBitmap REMOVE_FROM_GAME    = new DirectBitmap(Resources.remove_from_game, true);
        public static readonly DirectBitmap SWAP_TO_RED         = new DirectBitmap(Resources.swap_to_red, true);
        public static readonly DirectBitmap SWAP_TO_BLUE        = new DirectBitmap(Resources.swap_to_blue, true);
        public static readonly DirectBitmap SWAP_TO_SPECTATORS  = new DirectBitmap(Resources.swap_to_spectators, true);
        public static readonly DirectBitmap SWAP_TO_NEUTRAL     = new DirectBitmap(Resources.swap_to_neutral, true);
        public static readonly DirectBitmap REMOVE_ALL_BOTS     = new DirectBitmap(Resources.remove_all_bots, true);
        public static readonly DirectBitmap VIEW_CAREER_PROFILE = new DirectBitmap(Resources.view_career_profile, true);
        public static readonly DirectBitmap SEND_FRIEND_REQUEST = new DirectBitmap(Resources.send_friend_request, true);
        public static readonly DirectBitmap REMOVE_FRIEND       = new DirectBitmap(Resources.remove_friend, true);

        public static readonly DirectBitmap[] DIFFICULTY_MARKUPS = new DirectBitmap[]
        {
            new DirectBitmap(Resources.easy_difficulty, true),
            new DirectBitmap(Resources.medium_difficulty, true),
            new DirectBitmap(Resources.hard_difficulty, true)
        };
        public static readonly DirectBitmap[] HERO_MARKUPS = new DirectBitmap[]
        {
            new DirectBitmap(Resources.ana_markup, true), // Ana
            new DirectBitmap(Resources.bastion_markup, true), // Bastion
            new DirectBitmap(Resources.brigitte_markup, true), // Brigitte
            new DirectBitmap(Resources.dva_markup, true), // Dva
            new DirectBitmap(Resources.doomfist_markup, true), // Doomfist
            new DirectBitmap(Resources.gengi_markup, true), // Genji
            new DirectBitmap(Resources.hanzo_markup, true), // Hanzo
            new DirectBitmap(Resources.junkrat_markup, true), // Junkrat
            new DirectBitmap(Resources.lucio_markup, true), // Lucio
            new DirectBitmap(Resources.mccree_markup, true), // McCree
            new DirectBitmap(Resources.mei_markup, true), // Mei
            new DirectBitmap(Resources.mercy_markup, true), // Mercy
            new DirectBitmap(Resources.moira_markup, true), // Moira
            new DirectBitmap(Resources.orisa_markup, true), // Orisa
            new DirectBitmap(Resources.pharah_markup, true), // Pharah
            new DirectBitmap(Resources.reaper_markup, true), // Reaper
            new DirectBitmap(Resources.reinhardt_markup, true), // Reinhardt
            new DirectBitmap(Resources.roadhog_markup, true), // Roadhog
            new DirectBitmap(Resources.soldier_markup, true), // Soldier: 76
            new DirectBitmap(Resources.sombra_markup, true), // Sombra
            new DirectBitmap(Resources.symmetra_markup, true), // Symmetra
            new DirectBitmap(Resources.torbjorn_markup, true), // Torbjorn
            new DirectBitmap(Resources.tracer_markup, true), // Tracer
            new DirectBitmap(Resources.widowmaker_markup, true), // Widowmaker
            new DirectBitmap(Resources.winston_markup, true), // Winston
            new DirectBitmap(Resources.wreckingball_markup, true), // Wrecking Ball
            new DirectBitmap(Resources.zarya_markup, true), // Zarya
            new DirectBitmap(Resources.zenyatta_markup, true) // Zenyatta
        };

        public static readonly MapMarkup[] MAP_MARKUPS = new MapMarkup[]
        {
            new MapMarkup(new DirectBitmap(Resources.Antarctica, true),                Map.DM_Antarctica, Map.ELIM_Antarctica, Map.TDM_Antarctica),
            new MapMarkup(new DirectBitmap(Resources.Ayutthaya, true),                 Map.CTF_Ayutthaya, Map.ELIM_Ayutthaya),
            new MapMarkup(new DirectBitmap(Resources.BlackForest, true),               Map.DM_BlackForest, Map.ELIM_BlackForest, Map.TDM_BlackForest),
            new MapMarkup(new DirectBitmap(Resources.BlizzardWorld, true),             Map.AE_BlizzardWorld, Map.DM_BlizzardWorld, Map.SKIRM_BlizzardWorld, Map.TDM_BlizzardWorld),
            new MapMarkup(new DirectBitmap(Resources.Busan, true),                     Map.C_Busan, Map.SKIRM_Busan),
            new MapMarkup(new DirectBitmap(Resources.Castillo, true),                  Map.DM_Castillo, Map.ELIM_Castillo, Map.TDM_Castillo),
            new MapMarkup(new DirectBitmap(Resources.ChateauGuillard, true),           Map.DM_ChateauGuillard, Map.TDM_ChateauGuillard),
            new MapMarkup(new DirectBitmap(Resources.ChateauGuillard_Halloween, true), Map.DM_ChateauGuillard_Halloween, Map.TDM_ChateauGuillard_Halloween),
            new MapMarkup(new DirectBitmap(Resources.Dorado, true),                    Map.DM_Dorado, Map.E_Dorado, Map.SKIRM_Dorado, Map.TDM_Dorado),
            new MapMarkup(new DirectBitmap(Resources.Eichenwalde, true),               Map.AE_Eichenwalde, Map.DM_Eichenwalde, Map.SKIRM_Eichenwalde, Map.TDM_Eichenwalde),
            new MapMarkup(new DirectBitmap(Resources.Eichenwalde_Halloween, true),     Map.AE_Eichenwalde_Halloween, Map.DM_Eichenwalde_Halloween, Map.SKIRM_Eichenwalde_Halloween, Map.TDM_Eichenwalde_Halloween),
            new MapMarkup(new DirectBitmap(Resources.Gibraltar, true),                 Map.E_Gibraltar, Map.SKIRM_Gibraltar),
            new MapMarkup(new DirectBitmap(Resources.Hanamura, true),                  Map.A_Hanamura, Map.DM_Hanamura, Map.SKIRM_Hanamura, Map.TDM_Hanamura),
            new MapMarkup(new DirectBitmap(Resources.Hollywood, true),                 Map.AE_Hollywood, Map.DM_Hollywood, Map.SKIRM_Hollywood, Map.TDM_Hollywood),
            new MapMarkup(new DirectBitmap(Resources.Hollywood_Halloween, true),       Map.AE_Hollywood_Halloween, Map.DM_Hollywood_Halloween, Map.SKIRM_Hollywood_Halloween, Map.TDM_Hollywood_Halloween),
            new MapMarkup(new DirectBitmap(Resources.HorizonLunarColony, true),        Map.A_HorizonLunarColony, Map.DM_HorizonLunarColony, Map.SKIRM_HorizonLunarColony, Map.TDM_HorizonLunarColony),
            new MapMarkup(new DirectBitmap(Resources.Ilios, true),                     Map.C_Ilios, Map.SKIRM_Ilios),
            new MapMarkup(new DirectBitmap(Resources.Ilios_Lighthouse, true),          Map.CTF_Ilios_Lighthouse, Map.DM_Ilios_Lighthouse, Map.ELIM_Ilios_Lighthouse, Map.TDM_Ilios_Lighthouse),
            new MapMarkup(new DirectBitmap(Resources.Ilios_Ruins, true),               Map.CTF_Ilios_Ruins, Map.DM_Ilios_Ruins, Map.ELIM_Ilios_Ruins, Map.TDM_Ilios_Ruins),
            new MapMarkup(new DirectBitmap(Resources.Ilios_Well, true),                Map.CTF_Ilios_Well, Map.DM_Ilios_Well, Map.ELIM_Ilios_Well, Map.TDM_Ilios_Well),
            new MapMarkup(new DirectBitmap(Resources.Junkertown, true),                Map.E_Junkertown, Map.SKIRM_Junkertown),
            new MapMarkup(new DirectBitmap(Resources.KingsRow, true),                  Map.AE_KingsRow, Map.DM_KingsRow, Map.SKIRM_KingsRow, Map.TDM_KingsRow),
            new MapMarkup(new DirectBitmap(Resources.Lijiang, true),                   Map.C_Lijiang, Map.SKIRM_Lijiang),
            new MapMarkup(new DirectBitmap(Resources.Lijiang_ControlCenter, true),     Map.CTF_Lijiang_ControlCenter, Map.DM_Lijiang_ControlCenter, Map.ELIM_Lijiang_ControlCenter, Map.TDM_Lijiang_ControlCenter),
            new MapMarkup(new DirectBitmap(Resources.Lijiang_Garden, true),            Map.CTF_Lijiang_Garden, Map.DM_Lijiang_Garden, Map.ELIM_Lijiang_Garden, Map.TDM_Lijiang_Garden),
            new MapMarkup(new DirectBitmap(Resources.Lijiang_NightMarket, true),       Map.CTF_Lijiang_NightMarket, Map.DM_Lijiang_NightMarket, Map.ELIM_Lijiang_NightMarket, Map.TDM_Lijiang_NightMarket),
            new MapMarkup(new DirectBitmap(Resources.Necropolis, true),                Map.DM_Necropolis, Map.ELIM_Necropolis, Map.TDM_Necropolis),
            new MapMarkup(new DirectBitmap(Resources.Nepal, true),                     Map.C_Nepal, Map.SKIRM_Nepal),
            new MapMarkup(new DirectBitmap(Resources.Nepal_Sanctum, true),             Map.CTF_Nepal_Sanctum, Map.DM_Nepal_Sanctum, Map.ELIM_Nepal_Sanctum, Map.TDM_Nepal_Sanctum),
            new MapMarkup(new DirectBitmap(Resources.Nepal_Shrine, true),              Map.CTF_Nepal_Shrine, Map.DM_Nepal_Shrine, Map.ELIM_Nepal_Shrine, Map.TDM_Nepal_Shrine),
            new MapMarkup(new DirectBitmap(Resources.Nepal_Village, true),             Map.CTF_Nepal_Village, Map.DM_Nepal_Village, Map.ELIM_Nepal_Village, Map.TDM_Nepal_Village),
            new MapMarkup(new DirectBitmap(Resources.Numbani, true),                   Map.AE_Numbani, Map.SKIRM_Numbani),
            new MapMarkup(new DirectBitmap(Resources.Oasis, true),                     Map.C_Oasis, Map.SKIRM_Oasis),
            new MapMarkup(new DirectBitmap(Resources.Oasis_CityCenter, true),          Map.CTF_Oasis_CityCenter, Map.DM_Oasis_CityCenter, Map.ELIM_Oasis_CityCenter, Map.TDM_Oasis_CityCenter),
            new MapMarkup(new DirectBitmap(Resources.Oasis_Gardens, true),             Map.CTF_Oasis_Gardens, Map.DM_Oasis_Gardens, Map.ELIM_Oasis_Gardens, Map.TDM_Oasis_Gardens),
            new MapMarkup(new DirectBitmap(Resources.Oasis_University, true),          Map.CTF_Oasis_University, Map.DM_Oasis_University, Map.ELIM_Oasis_University, Map.TDM_Oasis_University),
            new MapMarkup(new DirectBitmap(Resources.Petra, true),                     Map.DM_Petra, Map.TDM_Petra),
            new MapMarkup(new DirectBitmap(Resources.Rialto, true),                    Map.E_Rialto, Map.SKIRM_Rialto),
            new MapMarkup(new DirectBitmap(Resources.Route66, true),                   Map.E_Route66, Map.SKIRM_Route66),
            new MapMarkup(new DirectBitmap(Resources.TempleOfAnubis, true),            Map.A_TempleOfAnubis, Map.DM_TempleOfAnubis, Map.SKIRM_TempleOfAnubis, Map.TDM_TempleOfAnubis),
            new MapMarkup(new DirectBitmap(Resources.VolskayaIndustries, true),        Map.A_VolskayaIndustries, Map.DM_VolskayaIndustries, Map.SKIRM_VolskayaIndustries, Map.TDM_VolskayaIndustries),
        };
    }

    internal class MapMarkup
    {
        public MapMarkup(DirectBitmap markup, params Map[] maps)
        {
            Markup = markup;
            Maps = maps;
        }
        public DirectBitmap Markup { get; private set; }
        public Map[] Maps { get; private set; }
    }
}