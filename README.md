<h2 align="center">Семинарска работа по Визуелно програмирање </h2> <br> <br>
<b>1)Краток опис на проблемот</b> <br> 
3in1Game е игра која што се состои од три различни дела т.е игри. Се работи за игра која им овозможува на корисниците да ги тестираат своите способности за меморирање и познавања од областа на филмовите и сето тоа за кратко време. Првиот дел е меморија која треба да се реши за одредено време, вториот дел е сложувалка која треба да се спои и да се погоди соодветниот актер и третиот дел е асоцијација каде треба да се погоди името на филмот за кратко време . Со цел да се обезбеди комплетно задоволство кај корисникот имплементиравме три различни нивоа на тежина:  Easy, Medium и Hard од кои корисникот може да си одбере.<br> <br>
<b>2) Функционалност и упатство за играње </b> <br> 
<b>2.1)</b> На почетниот прозорец при стартување на апликацијата се внесува името на играчот, се избира едно од трите нивоа на тежина и се започнува играта. <br> <br>
<b>2.2)</b> Првиот дел од играта се состои од меморија каде целта е при кликање да се погодат две исти слики. Има можност за паузирање на меморијата и нејзино продолжување, а исто така има и време за кое корисникот треба да ја реши. Се додека не ја реши меморијата не може да премине на следната игра (ниво). <br><br>
<b>2.3)</b> Вториот дел од играта се состои од два поддела.Првиот дел е сложувалка која треба да се спои за да се добие оргиналната слика, а во вториот дел корисникот има можност да го погоди актерот согласно со сликата.  Двата дела се независни односно корисникот може да ја реши само сложувалката или само да го погоди актерот, а може и двете. Откако ќе го направи тоа може да премине на последната игра. <br><br>
<b>2.4)</b> Третиот дел претставува еден вид на асоцијација во која корисникот според дадените зборчиња треба да го погоди филмот за многу кратко време. На почетокот има понудено само едно зборче, останатите 2 се скриени, а има и уште едно поле кое е слика од филмот. Поените се скалираат во зависност од тоа колку зборчиња има отворено корисникот(отворена слика носи најмалку поени).Доколку не се погоди точното име на филмот, му се дава можност на корисникот да погодува се додека не истече времто.Кога ќе истече времето или пак се погоди филмот, играта завршува. Се јавува MessageBox со  YesNoCancel каде корисникот може да започне нова игра(yes), да ја исклучи апликацијата (no) или пак да остане на последната игра (cancel) каде има можност да ги види сите играчи (Best players) сортирани според бројот на освоени поени. Исто така доколку претходно кликнал cancel и се предомисли дека сака повторно да игра, има можност за тоа со кликање на Play again од menuStrip-от. <br> <br>
<b>3) Структура и организација на код </b> <br>
Апликацијата е составена од по 3 форми за секое ниво на тежина и една форма која служи за логирање. На формите се среќаваат лабели, копчиња, панели, тајмери, radioButton-и и pictureBox-и кои овозможуваат во нив да се сместат сите слики кои се потребни за меморијата и сложувалката. <br> <br>
<b>3.1)</b> За меморијата ни беше потребна една IEnumerable колекција од Image во која што ги чувавме сите слики од кои требаше да биде составена меморијата , static променлива во која се чуваат поените освоени од сите три игри, два тајмера-еден кој го одбројува преостанатото време за играње, а другиот на колку време да се скријат отворените слики, една класа Player во која се чуваат името, поените и нивото на тежина на играта и неколку функции како што се:<br>
<ul>
<li>HideImage() </li>
<li>ResetImage() </li>
<li>ClickImage() </li>
<li>SetRandomImage() </li>
<li>getFreeSlot() </li>
</ul>
<b>3.2)</b> За втората игра потребни ни беа неколку листи од Bitmap во која што се чуваат делчињата од оргиналните слики, една листа од стрингови во која се чуваат точните одговори (имињата на актерите) кои одговараат на сликата, еден рандом кој што избира една од листите со деловите од сликите и ги пополнува рандом pictureBox-ите на формата и една листа која ги содржи по ред како треба да бидат наместени делчињата. Функции кои ни беа потребни за овој дел се: <br>
<ul>
<li>	Hit() </li>
<li>	CheckWin()</li>
<li>	SwitchPictureBox()</li>
<li>	Shuffle()</li>
</ul>
<b>3.3)</b> За последната игра Асоцијација имавме потреба од една класа Words во која се чуваат името на филмот, сликата и листа од стрингови во која се чуваат зборови кои се асоцијација на дадениот филм, bool променлива дали некое зборче е отворено,листа од зборови и следниве функции: <br>
<ul>
<li>	StartGameTimer() </li>
<li>	Fill()</li>
<li>	BestPlayers()</li>
<li>	GameOver()</li>
<li>	HideLabels()</li>
<li>GuessWord()</li>
<li>	Selected()</li>
</ul> 
<b>4)Опис на некои функции </b> <br>
<b>4.1)</b> Од втората игра-Сложувалка
<ul>
<li>Hit()-која проверува дали селектираниот одговор од корисникот е точен</li>
<li>CheckWin()-која проверува дали деловите од сликите се наместени по ред како во оргиналната листа</li>
<li>SwitchPictureBox()-која овозможува корисникот да може да ги мести деловите на сликите со цел да се добие оргиналната слика</li>
<li>Shuffle()-која што овозможува при секое отварање на формата,PictureBox-ите рандом да се пополнат со делчиња од сликите </li>
</ul>
<b>4.2) </b>Од третата игра-Асоцијација
<ul>
<li>Функцијата Fill() служи за полнење на листата од зборови со филмовите кои ќе се погодуваат и за таа цел ни беа потребни еден збор (објект од класата Words) и листа од зборови.На секој збор му задававме име на филмот, слика и асоцијации кои одговараат на тој филм и потоа тој збор  го додаваме во листата со зборови.</li>
<li>Функцијата Selected() служи за рандом избирање на еден од филмовите.Избраниот филм се чува во една променлива selectedWord и потоа трите лабели на формата се полнат со рандом избор на асоцијативни зборчиња кои одговараат на тој филм.Доколку се случи втората или третата лабела да се пополнети со ист збор кој веке постои на формата тогаш повторно се избира нов збор за тие две лабели се додека не бидат различни сите три асоцијативни збора.</li>
</ul>

<b>Изработиле:</b> <br>
Андријана Пандуловска 163008<br>
Софија Панова 163009<br>
Викторија Коцева 163040<br>
