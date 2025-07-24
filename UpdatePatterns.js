// The patterns are ripped off https://github.com/sindresorhus/cli-spinners
const res = await fetch("https://raw.githubusercontent.com/sindresorhus/cli-spinners/refs/heads/main/spinners.json");
const json = JSON.parse(await res.text());
const patterns = Object.keys(json).map(x => ({ key: x[0].toUpperCase() + x.substring(1), value: json[x] })).map(x => [`        public static readonly Pattern ${x.key} = new([`, x.value.frames.map(x => '            "' + x.replace('\\', '\\\\') + '"').join(",\n"), `        ], interval: ${x.value.interval});`].join("\n")).join("\n\n");

const cs = `namespace Kurukuru
{
    // The patterns are ripped off https://github.com/sindresorhus/cli-spinners
    public class Patterns
    {
${patterns}
    }
}`;

console.log(cs)
