using System;
using System.Collections.Generic;
using System.Text;

namespace Kurukuru
{
    // The patterns are ripped off https://github.com/sindresorhus/cli-spinners
    // Object.keys(json).map(x => ({ key: x[0].toUpperCase() + x.substring(1), value: json[x] })).map(x => [`        public static readonly Pattern ${x.key} = new Pattern(new string[]`, `        {`, x.value.frames.map(x => '            "' + x.replace('\\', '\\\\') + '"').join(",\n"), `        }, interval: ${x.value.interval});`].join("\n")).join("\n\n")
    public class Patterns
    {
        public static readonly Pattern Dots = new Pattern(new string[]
        {
            "⠋",
            "⠙",
            "⠹",
            "⠸",
            "⠼",
            "⠴",
            "⠦",
            "⠧",
            "⠇",
            "⠏"
        }, interval: 80);

        public static readonly Pattern Dots2 = new Pattern(new string[]
        {
            "⣾",
            "⣽",
            "⣻",
            "⢿",
            "⡿",
            "⣟",
            "⣯",
            "⣷"
        }, interval: 80);

        public static readonly Pattern Dots3 = new Pattern(new string[]
        {
            "⠋",
            "⠙",
            "⠚",
            "⠞",
            "⠖",
            "⠦",
            "⠴",
            "⠲",
            "⠳",
            "⠓"
        }, interval: 80);

        public static readonly Pattern Dots4 = new Pattern(new string[]
        {
            "⠄",
            "⠆",
            "⠇",
            "⠋",
            "⠙",
            "⠸",
            "⠰",
            "⠠",
            "⠰",
            "⠸",
            "⠙",
            "⠋",
            "⠇",
            "⠆"
        }, interval: 80);

        public static readonly Pattern Dots5 = new Pattern(new string[]
        {
            "⠋",
            "⠙",
            "⠚",
            "⠒",
            "⠂",
            "⠂",
            "⠒",
            "⠲",
            "⠴",
            "⠦",
            "⠖",
            "⠒",
            "⠐",
            "⠐",
            "⠒",
            "⠓",
            "⠋"
        }, interval: 80);

        public static readonly Pattern Dots6 = new Pattern(new string[]
        {
            "⠁",
            "⠉",
            "⠙",
            "⠚",
            "⠒",
            "⠂",
            "⠂",
            "⠒",
            "⠲",
            "⠴",
            "⠤",
            "⠄",
            "⠄",
            "⠤",
            "⠴",
            "⠲",
            "⠒",
            "⠂",
            "⠂",
            "⠒",
            "⠚",
            "⠙",
            "⠉",
            "⠁"
        }, interval: 80);

        public static readonly Pattern Dots7 = new Pattern(new string[]
        {
            "⠈",
            "⠉",
            "⠋",
            "⠓",
            "⠒",
            "⠐",
            "⠐",
            "⠒",
            "⠖",
            "⠦",
            "⠤",
            "⠠",
            "⠠",
            "⠤",
            "⠦",
            "⠖",
            "⠒",
            "⠐",
            "⠐",
            "⠒",
            "⠓",
            "⠋",
            "⠉",
            "⠈"
        }, interval: 80);

        public static readonly Pattern Dots8 = new Pattern(new string[]
        {
            "⠁",
            "⠁",
            "⠉",
            "⠙",
            "⠚",
            "⠒",
            "⠂",
            "⠂",
            "⠒",
            "⠲",
            "⠴",
            "⠤",
            "⠄",
            "⠄",
            "⠤",
            "⠠",
            "⠠",
            "⠤",
            "⠦",
            "⠖",
            "⠒",
            "⠐",
            "⠐",
            "⠒",
            "⠓",
            "⠋",
            "⠉",
            "⠈",
            "⠈"
        }, interval: 80);

        public static readonly Pattern Dots9 = new Pattern(new string[]
        {
            "⢹",
            "⢺",
            "⢼",
            "⣸",
            "⣇",
            "⡧",
            "⡗",
            "⡏"
        }, interval: 80);

        public static readonly Pattern Dots10 = new Pattern(new string[]
        {
            "⢄",
            "⢂",
            "⢁",
            "⡁",
            "⡈",
            "⡐",
            "⡠"
        }, interval: 80);

        public static readonly Pattern Dots11 = new Pattern(new string[]
        {
            "⠁",
            "⠂",
            "⠄",
            "⡀",
            "⢀",
            "⠠",
            "⠐",
            "⠈"
        }, interval: 100);

        public static readonly Pattern Dots12 = new Pattern(new string[]
        {
            "⢀⠀",
            "⡀⠀",
            "⠄⠀",
            "⢂⠀",
            "⡂⠀",
            "⠅⠀",
            "⢃⠀",
            "⡃⠀",
            "⠍⠀",
            "⢋⠀",
            "⡋⠀",
            "⠍⠁",
            "⢋⠁",
            "⡋⠁",
            "⠍⠉",
            "⠋⠉",
            "⠋⠉",
            "⠉⠙",
            "⠉⠙",
            "⠉⠩",
            "⠈⢙",
            "⠈⡙",
            "⢈⠩",
            "⡀⢙",
            "⠄⡙",
            "⢂⠩",
            "⡂⢘",
            "⠅⡘",
            "⢃⠨",
            "⡃⢐",
            "⠍⡐",
            "⢋⠠",
            "⡋⢀",
            "⠍⡁",
            "⢋⠁",
            "⡋⠁",
            "⠍⠉",
            "⠋⠉",
            "⠋⠉",
            "⠉⠙",
            "⠉⠙",
            "⠉⠩",
            "⠈⢙",
            "⠈⡙",
            "⠈⠩",
            "⠀⢙",
            "⠀⡙",
            "⠀⠩",
            "⠀⢘",
            "⠀⡘",
            "⠀⠨",
            "⠀⢐",
            "⠀⡐",
            "⠀⠠",
            "⠀⢀",
            "⠀⡀"
        }, interval: 80);

        public static readonly Pattern Line = new Pattern(new string[]
        {
            "-",
            "\\",
            "|",
            "/"
        }, interval: 130);

        public static readonly Pattern Line2 = new Pattern(new string[]
        {
            "⠂",
            "-",
            "–",
            "—",
            "–",
            "-"
        }, interval: 100);

        public static readonly Pattern Pipe = new Pattern(new string[]
        {
            "┤",
            "┘",
            "┴",
            "└",
            "├",
            "┌",
            "┬",
            "┐"
        }, interval: 100);

        public static readonly Pattern SimpleDots = new Pattern(new string[]
        {
            ".  ",
            ".. ",
            "...",
            "   "
        }, interval: 400);

        public static readonly Pattern SimpleDotsScrolling = new Pattern(new string[]
        {
            ".  ",
            ".. ",
            "...",
            " ..",
            "  .",
            "   "
        }, interval: 200);

        public static readonly Pattern Star = new Pattern(new string[]
        {
            "✶",
            "✸",
            "✹",
            "✺",
            "✹",
            "✷"
        }, interval: 70);

        public static readonly Pattern Star2 = new Pattern(new string[]
        {
            "+",
            "x",
            "*"
        }, interval: 80);

        public static readonly Pattern Flip = new Pattern(new string[]
        {
            "_",
            "_",
            "_",
            "-",
            "`",
            "`",
            "'",
            "´",
            "-",
            "_",
            "_",
            "_"
        }, interval: 70);

        public static readonly Pattern Hamburger = new Pattern(new string[]
        {
            "☱",
            "☲",
            "☴"
        }, interval: 100);

        public static readonly Pattern GrowVertical = new Pattern(new string[]
        {
            "▁",
            "▃",
            "▄",
            "▅",
            "▆",
            "▇",
            "▆",
            "▅",
            "▄",
            "▃"
        }, interval: 120);

        public static readonly Pattern GrowHorizontal = new Pattern(new string[]
        {
            "▏",
            "▎",
            "▍",
            "▌",
            "▋",
            "▊",
            "▉",
            "▊",
            "▋",
            "▌",
            "▍",
            "▎"
        }, interval: 120);

        public static readonly Pattern Balloon = new Pattern(new string[]
        {
            " ",
            ".",
            "o",
            "O",
            "@",
            "*",
            " "
        }, interval: 140);

        public static readonly Pattern Balloon2 = new Pattern(new string[]
        {
            ".",
            "o",
            "O",
            "°",
            "O",
            "o",
            "."
        }, interval: 120);

        public static readonly Pattern Noise = new Pattern(new string[]
        {
            "▓",
            "▒",
            "░"
        }, interval: 100);

        public static readonly Pattern Bounce = new Pattern(new string[]
        {
            "⠁",
            "⠂",
            "⠄",
            "⠂"
        }, interval: 120);

        public static readonly Pattern BoxBounce = new Pattern(new string[]
        {
            "▖",
            "▘",
            "▝",
            "▗"
        }, interval: 120);

        public static readonly Pattern BoxBounce2 = new Pattern(new string[]
        {
            "▌",
            "▀",
            "▐",
            "▄"
        }, interval: 100);

        public static readonly Pattern Triangle = new Pattern(new string[]
        {
            "◢",
            "◣",
            "◤",
            "◥"
        }, interval: 50);

        public static readonly Pattern Arc = new Pattern(new string[]
        {
            "◜",
            "◠",
            "◝",
            "◞",
            "◡",
            "◟"
        }, interval: 100);

        public static readonly Pattern Circle = new Pattern(new string[]
        {
            "◡",
            "⊙",
            "◠"
        }, interval: 120);

        public static readonly Pattern SquareCorners = new Pattern(new string[]
        {
            "◰",
            "◳",
            "◲",
            "◱"
        }, interval: 180);

        public static readonly Pattern CircleQuarters = new Pattern(new string[]
        {
            "◴",
            "◷",
            "◶",
            "◵"
        }, interval: 120);

        public static readonly Pattern CircleHalves = new Pattern(new string[]
        {
            "◐",
            "◓",
            "◑",
            "◒"
        }, interval: 50);

        public static readonly Pattern Squish = new Pattern(new string[]
        {
            "╫",
            "╪"
        }, interval: 100);

        public static readonly Pattern Toggle = new Pattern(new string[]
        {
            "⊶",
            "⊷"
        }, interval: 250);

        public static readonly Pattern Toggle2 = new Pattern(new string[]
        {
            "▫",
            "▪"
        }, interval: 80);

        public static readonly Pattern Toggle3 = new Pattern(new string[]
        {
            "□",
            "■"
        }, interval: 120);

        public static readonly Pattern Toggle4 = new Pattern(new string[]
        {
            "■",
            "□",
            "▪",
            "▫"
        }, interval: 100);

        public static readonly Pattern Toggle5 = new Pattern(new string[]
        {
            "▮",
            "▯"
        }, interval: 100);

        public static readonly Pattern Toggle6 = new Pattern(new string[]
        {
            "ဝ",
            "၀"
        }, interval: 300);

        public static readonly Pattern Toggle7 = new Pattern(new string[]
        {
            "⦾",
            "⦿"
        }, interval: 80);

        public static readonly Pattern Toggle8 = new Pattern(new string[]
        {
            "◍",
            "◌"
        }, interval: 100);

        public static readonly Pattern Toggle9 = new Pattern(new string[]
        {
            "◉",
            "◎"
        }, interval: 100);

        public static readonly Pattern Toggle10 = new Pattern(new string[]
        {
            "㊂",
            "㊀",
            "㊁"
        }, interval: 100);

        public static readonly Pattern Toggle11 = new Pattern(new string[]
        {
            "⧇",
            "⧆"
        }, interval: 50);

        public static readonly Pattern Toggle12 = new Pattern(new string[]
        {
            "☗",
            "☖"
        }, interval: 120);

        public static readonly Pattern Toggle13 = new Pattern(new string[]
        {
            "=",
            "*",
            "-"
        }, interval: 80);

        public static readonly Pattern Arrow = new Pattern(new string[]
        {
            "←",
            "↖",
            "↑",
            "↗",
            "→",
            "↘",
            "↓",
            "↙"
        }, interval: 100);

        public static readonly Pattern Arrow2 = new Pattern(new string[]
        {
            "⬆️ ",
            "↗️ ",
            "➡️ ",
            "↘️ ",
            "⬇️ ",
            "↙️ ",
            "⬅️ ",
            "↖️ "
        }, interval: 80);

        public static readonly Pattern Arrow3 = new Pattern(new string[]
        {
            "▹▹▹▹▹",
            "▸▹▹▹▹",
            "▹▸▹▹▹",
            "▹▹▸▹▹",
            "▹▹▹▸▹",
            "▹▹▹▹▸"
        }, interval: 120);

        public static readonly Pattern BouncingBar = new Pattern(new string[]
        {
            "[    ]",
            "[=   ]",
            "[==  ]",
            "[=== ]",
            "[ ===]",
            "[  ==]",
            "[   =]",
            "[    ]",
            "[   =]",
            "[  ==]",
            "[ ===]",
            "[====]",
            "[=== ]",
            "[==  ]",
            "[=   ]"
        }, interval: 80);

        public static readonly Pattern BouncingBall = new Pattern(new string[]
        {
            "( ●    )",
            "(  ●   )",
            "(   ●  )",
            "(    ● )",
            "(     ●)",
            "(    ● )",
            "(   ●  )",
            "(  ●   )",
            "( ●    )",
            "(●     )"
        }, interval: 80);

        public static readonly Pattern Smiley = new Pattern(new string[]
        {
            "😄 ",
            "😝 "
        }, interval: 200);

        public static readonly Pattern Monkey = new Pattern(new string[]
        {
            "🙈 ",
            "🙈 ",
            "🙉 ",
            "🙊 "
        }, interval: 300);

        public static readonly Pattern Hearts = new Pattern(new string[]
        {
            "💛 ",
            "💙 ",
            "💜 ",
            "💚 ",
            "❤️ "
        }, interval: 100);

        public static readonly Pattern Clock = new Pattern(new string[]
        {
            "🕛 ",
            "🕐 ",
            "🕑 ",
            "🕒 ",
            "🕓 ",
            "🕔 ",
            "🕕 ",
            "🕖 ",
            "🕗 ",
            "🕘 ",
            "🕙 ",
            "🕚 "
        }, interval: 100);

        public static readonly Pattern Earth = new Pattern(new string[]
        {
            "🌍 ",
            "🌎 ",
            "🌏 "
        }, interval: 180);

        public static readonly Pattern Moon = new Pattern(new string[]
        {
            "🌑 ",
            "🌒 ",
            "🌓 ",
            "🌔 ",
            "🌕 ",
            "🌖 ",
            "🌗 ",
            "🌘 "
        }, interval: 80);

        public static readonly Pattern Runner = new Pattern(new string[]
        {
            "🚶 ",
            "🏃 "
        }, interval: 140);

        public static readonly Pattern Pong = new Pattern(new string[]
        {
            "▐⠂       ▌",
            "▐⠈       ▌",
            "▐ ⠂      ▌",
            "▐ ⠠      ▌",
            "▐  ⡀     ▌",
            "▐  ⠠     ▌",
            "▐   ⠂    ▌",
            "▐   ⠈    ▌",
            "▐    ⠂   ▌",
            "▐    ⠠   ▌",
            "▐     ⡀  ▌",
            "▐     ⠠  ▌",
            "▐      ⠂ ▌",
            "▐      ⠈ ▌",
            "▐       ⠂▌",
            "▐       ⠠▌",
            "▐       ⡀▌",
            "▐      ⠠ ▌",
            "▐      ⠂ ▌",
            "▐     ⠈  ▌",
            "▐     ⠂  ▌",
            "▐    ⠠   ▌",
            "▐    ⡀   ▌",
            "▐   ⠠    ▌",
            "▐   ⠂    ▌",
            "▐  ⠈     ▌",
            "▐  ⠂     ▌",
            "▐ ⠠      ▌",
            "▐ ⡀      ▌",
            "▐⠠       ▌"
        }, interval: 80);

        public static readonly Pattern Shark = new Pattern(new string[]
        {
            "▐|\\____________▌",
            "▐_|\\___________▌",
            "▐__|\\__________▌",
            "▐___|\\_________▌",
            "▐____|\\________▌",
            "▐_____|\\_______▌",
            "▐______|\\______▌",
            "▐_______|\\_____▌",
            "▐________|\\____▌",
            "▐_________|\\___▌",
            "▐__________|\\__▌",
            "▐___________|\\_▌",
            "▐____________|\\▌",
            "▐____________/|▌",
            "▐___________/|_▌",
            "▐__________/|__▌",
            "▐_________/|___▌",
            "▐________/|____▌",
            "▐_______/|_____▌",
            "▐______/|______▌",
            "▐_____/|_______▌",
            "▐____/|________▌",
            "▐___/|_________▌",
            "▐__/|__________▌",
            "▐_/|___________▌",
            "▐/|____________▌"
        }, interval: 120);

        public static readonly Pattern Dqpb = new Pattern(new string[]
        {
            "d",
            "q",
            "p",
            "b"
        }, interval: 100);

        public static readonly Pattern Weather = new Pattern(new string[]
        {
            "☀️ ",
            "☀️ ",
            "☀️ ",
            "🌤 ",
            "⛅️ ",
            "🌥 ",
            "☁️ ",
            "🌧 ",
            "🌨 ",
            "🌧 ",
            "🌨 ",
            "🌧 ",
            "🌨 ",
            "⛈ ",
            "🌨 ",
            "🌧 ",
            "🌨 ",
            "☁️ ",
            "🌥 ",
            "⛅️ ",
            "🌤 ",
            "☀️ ",
            "☀️ "
        }, interval: 100);

        public static readonly Pattern Christmas = new Pattern(new string[]
        {
            "🌲",
            "🎄"
        }, interval: 400);
    }

    public class Pattern
    {
        public string[] Frames { get; }
        public int Interval { get; }

        public Pattern(string[] frames, int interval)
        {
            Frames = frames;
            Interval = interval;
        }
    }
}
