Random rnd = new();

int[] tomb = new int[100];
for (int i = 0; i < tomb.Length; i++)
{
    tomb[i] = rnd.Next(200, 2000) * 5;
    if ((i + 1) % 7 == 0) Console.ForegroundColor = ConsoleColor.Green;
    Console.Write($"{tomb[i]} ");
    Console.ResetColor();
    if ((i + 1) % 10 == 0) Console.Write('\n');
}
Console.ForegroundColor = ConsoleColor.Red;

Console.WriteLine($"\ntömb elemeinek összege: {tomb.Sum()}");
int sum4K5K = 0;
int count4K5K = 0;
foreach (var e in tomb)
{
    if (e >= 4000 && e < 5000)
    {
        sum4K5K += e;
        count4K5K++;
    }
}
Console.WriteLine($"[4000, 5000) közti elemek átlaga: " +
    $"{sum4K5K / (float)count4K5K}");

int maxi = 0;
for (int i = 1; i < tomb.Length; i++)
    if (tomb[i] > tomb[maxi]) maxi = i;
Console.WriteLine($"A legnagyobb elem ({tomb[maxi]}) " +
    $"a(z) {maxi / 10 + 1}. sor, {maxi % 10 + 1}. oszlopban van.");

int sum25K = 0;
int index = 0;
while (sum25K <= 25000)
{
    sum25K += tomb[index];
    index++;
}
Console.WriteLine($"a tömb {index} db elemét kell összeadni az elejétől, " +
    $"hogy meghaladjuk a 25K-t");

index = 0;
while (index < tomb.Length && tomb[index] % 65 != 0) index++;
if (index < tomb.Length)
    Console.WriteLine($"az első szám, mely 65 többszöröse: " +
        $"{tomb[index]}, indexe: {index}");
else Console.WriteLine($"nincs a tömbben 65 többszöröse");
int count3Ke = 0;
foreach (var e in tomb)
{
    if (e >= 3000 && e < 4000) count3Ke++;
}
Console.WriteLine($"összesen {count3Ke} db 3mas számmal kezdődő elem van a tömbben");

index = 0;
int elfogadhato = 4500;
while (index < tomb.Length && tomb[index] < elfogadhato) index++;
if (index < tomb.Length)
    Console.WriteLine($"szerintem a {tomb[index]} (a tömb {index}. indexű eleme) " +
    $"már elfogadható órabér (vagy több).");
else Console.WriteLine("nincs a tömbben számomra elfogadható fizetés :(");

int[] masik = new int[100];
index = 0;
for (int i = 0; i < tomb.Length; i++)
{
    if (tomb[i] % 100 == 0)
    {
        masik[index] = tomb[i];
        index++;
    }
}
Array.Resize(ref masik, index);
Console.ResetColor();

for (int i = 0; i < masik.Length; i++)
{
    if (masik[i].ToString()[0] == masik[i].ToString()[1])
        Console.BackgroundColor = ConsoleColor.Red;
    Console.Write($"{masik[i]}");
    Console.ResetColor();
    Console.Write(" ");
    if ((i + 1) % 10 == 0) Console.Write('\n');
}

int szulev = 1990;
int kerekitett = szulev;
if (szulev % 5 == 1 || szulev % 5 == 2) kerekitett = szulev - szulev % 5;
else if (szulev % 5 == 3 || szulev % 5 == 4) kerekitett = szulev + (5 - szulev % 5);
//Console.WriteLine($"\neredeti szé:    {szulev}");
//Console.WriteLine($"kerekített szé: {kerekitett}");

index = 0;
while (index < tomb.Length && tomb[index] != kerekitett) index++;
if (index < tomb.Length) Console.WriteLine($"\na {kerekitett} benne van a tömbben");
else Console.WriteLine($"\na {kerekitett} nincs benne a tömbben");

Console.ReadKey(true);