/*
 

 
                                                System Programlaşdırma
 
 System Programlaşdırma - Asinxron programlaşdırmanı öyrənəcəyik ki biz kodun və kod parçalarının bir yerdə necə sinxron şəkildə işləməsini öyrənəcəyik.
 
 
 Core - Nüvə kimi tərcümə olunur. İlkin zamanlarda kompyuterlər tək nüvəli (Single Core) idi və bunlar eyni zamanda sadəcə bir process yerinə yetirə bilirdi. 
Yəni processlər bir birinin ardınca işləyirdi ki növbəti processə keçmək üçün digər process də dayanmalı idi. Bunun üçündə TimeSharing üsulu yaradıldı.
Yəni hər processə müəyyən zaman aralığı verilir və həmin zaman aralığında process öz işini görür. Əgər vaxt bitərsə növbəti processə keçilir.

Növbəti dövrlərdə MultiTasking və MultiUser əməliyyat sistemləri yarandı. MultiTasking - eyni zamanda bir neçə processin işləməsi, 
MultiUser - eyni zamanda bir neçə istifadəçinin eyni kompyuterdə işləməsi.

Bunun üçündə Scheduler (Planlaşdırıcı) yaradıldı. Planlaşdırıcı hər processə müəyyən zaman aralığı verir və həmin zaman aralığında 
process öz işini görür. Əgər vaxt bitərsə növbəti processə keçilir.
SingleCore zamanı eyni anda bir neçə programın işləməsini bu Scheduler təmin edirdi. Bu zamanda Scheduler switching (keçid) üsulundan istifadə edirdi.

Switching - yəni bir processdən digər processə keçid. Bu keçid zamanı müəyyən zaman itkisi olurdu. Məsələn 1ms vaxt itkisi.
Bu process zamanı Scheduler bu processləri çox qısa bir müddətdə dəyişir və bu zaman itkisini istifadəçi hiss etmir. Amma əgər çox s
ayda process olarsa bu zaman itkisi yığılır və sistem yavaş işləməyə başlayır.

Daha sonrada MultiCore (Çox Nüvəli) kompyuterlər yarandı. MultiCore kompyuterlərdə eyni zamanda bir neçə process işləyə bilir.  
Hər bir Core (nüvə) öz özlüyündə bir process yerinə yetirə bilir. Məsələn 4 Core-lu bir kompyuterdə eyni zamanda 4 process işləyə bilər.
Və buna görə də artıq TimeSlice çox azaldıldı. Məsələn 1ms-dən 0.1ms-ə endirildi. Çünki artıq eyni zamanda bir neçə process işləyə bilir.
Amma niyə nüvələrin sayı artırılmır? Çünki nüvələrin sayı artırıldıqca kompyuterin qiyməti artır. Və bu da hər kəsin ala bilməyəcəyi bir şey olur.
Buda öz özlüyündə artıq isinmə və yüksək enerji sərfiyyatına səbəb olur. Buda standart 8 Core-dan yuxarı nüvələrin sayının artırılmamasına səbəb olur.
Bunu da bizim üçün CPU (Central Processing Unit - Mərkəzi Emal Vahidi) idarə edir.


Parallelism - Paralellik - Əgər bizim 4 nüvəli kompyuterimiz varsa və biz 4 processi eyni anda işlətmək istəyiriksə bu zaman paralellikdən istifadə edirik. 
Concurency - Eyni zamanda bir neçə işin görülməsi. Məsələn 4 nüvəli kompyuterimiz var və biz 8 processi eyni anda işlətmək istəyiriksə bu zaman concurency-dən istifadə edirik.
Concurency bizim yuxarıda başa saldığımız məntiqdir ki hərbir process işləmək istəyir amma scheduler bu processlərin hər birinə müəyyən zaman aralığı verir ki öz işini görsün.


MultiTasking - Eyni zamanda bir neçə processin işləməsi.

MultiThreading - Bir processin daxilində eyni zamanda bir neçə thread-in işləməsi. Hər bir processin daxilində bir və ya bir neçə thread ola bilər.
Thread - Axın - Hər bir thread öz daxilində bir iş görür. Məsələn bir web browser proqramı var. Bu proqramın daxilində bir neçə thread ola bilər.

İndi gəlin bu iki terminin əsas fərqlərinə baxaq.
1. Basic fərq:
    - MultiTasking - CPU-nun eyni zamanda bir neçə processi işlətməsidir.
    - MultiThreading - CPU-nun eyni zamanda bir processin daxilində bir neçə thread-i işlətməsidir. 

2. Switching (Keçid) fərqi:
    - MultiTasking - Processlər arasında keçid olur. Məsələn process1 işləyir, sonra process2 işləyir.
    - MultiThreading - Process daxilindəki Threadlər arasında keçid olur. Məsələn thread1 işləyir, sonra thread2 işləyir.

3. Memory and Resource  (Yaddaş və Resurs ) fərqi:
    - MultiTasking - Hər bir process öz yaddaş sahəsinə malikdir və digər processlərin yaddaş sahəsinə daxil ola bilməz.
    - MultiThreading - Eyni process daxilindəki bütün threadlər eyni yaddaş sahəsini paylaşır və bir thread digər threadin yaddaş sahəsinə daxil ola bilər.

4. Speed:
    - MultiTasking - Hesablama gücünü artırmaq üçün CPU əlavə nüvələrdən istifadə edir.
    - MultiThreading - Hesablama gücünü artırmaq üçün processə threadlar əlavə edilir.

5. 

Thread daxilində stack və register sahəsi olur. Amma heap sahəsi bütün threadlər tərəfindən paylaşılır.
Register - Qeydiyyatçı - CPU-nun daxilində olan kiçik yaddaş sahəsidir. Hər bir threadin öz register sahəsi olur.
Stack - Yığın - Hər bir threadin öz stack sahəsi olur. Stack sahəsi threadin daxilindəki dəyişənləri saxlayır.



Application - Proqram - İstifadəçi tərəfindən işlədilən proqramdır. Məsələn web browser, text editor və s.
Process - Proses - İcra edilən proqramın nümunəsidir. Hər bir proqram işlədikdə bir və ya bir neçə proses yaranır.


32 bitlik kompyuterlərdə 2^32 yaddaş ünvanı var. Yəni 4GB yaddaş ünvanı var. Əməliyyat yaddaşının ala biləcəyi datanın ölçüsü 4GB-dan çox ola bilməz.
64 bitlik kompyuterlərdə 2^64 yaddaş ünvanı var. Yəni 16EB yaddaş ünvanı var. Əməliyyat yaddaşının ala biləcəyi datanın ölçüsü 16EB-dan çox ola bilməz.


                                                            Properties

Properties - Hər bir processin öz propertieləri varki bu propertielər processin işləmə qaydasını və xüsusiyyətlərini müəyyən edir.
ProcessName - Processin adı
Id - Processin unikal identifikatoru (ID). Hər dəfə dynamic olaraq Əməliyyat sistemi tərəfindən təyin olunur.
Process.Start("ProcessName") - Processi işə salmaq üçün istifadə olunur. 
BasePriority - Processin əsas prioriteti. Prioritet nə qədər yüksəkdirsə process o qədər tez işlənir.
5 əsas prioritet var:
    - RealTime (Ən yüksək prioritet)
    - High
    - AboveNormal
    - Normal (Default)
    - BelowNormal
    - Idle (Ən aşağı prioritet)


Bu methodları istifadə etmək üçün System.Diagnostics namespace-ni əlavə etmək lazımdır.

var process = Process.GetProcessById(1234); // ID-si 1234 olan prosesi əldə edir.
Console.WriteLine(process.ProcessName); // Prosesi adını yazdırır.
process.Kill(); // Prosesi öldürür.

var preocesses = Process.GetProcesses(); // Bütün prosesləri əldə edir.
foreach (var proc in preocesses)
{
    Console.WriteLine($"{proc.Id} - {proc.ProcessName}");
}

var calculator = Process.GetProcessByName("Calculator"); // Adı Calculator olan prosesi əldə edir.

 
 
                                                                                Thread

Thread - Axın - Hər bir processin daxilində bir və ya bir neçə thread ola bilər. Hər bir thread öz daxilində bir iş görür. 
Məsələn bir web browser proqramı var. Bu proqramın daxilində bir neçə thread ola bilər. Bu threadlərdən biri web səhifəsini yükləyir, digəri istifadəçi ilə qarşılıqlı əlaqə yaradır,
Hər bir threadin öz propertieləri və methodları olur.
Thread.GetCurrentThread() - Cari thread-i əldə edir.
Thread.Sleep(1000) - Cari thread-i müəyyən müddət (1000ms) dayandırır.
Thread.GetCurrentThread().Name - Cari thread-in adını əldə edir.
Thread.GetCurrentThread().Priority - Cari thread-in prioritetini əldə edir.
Thread.GetCurrentThread().Id - Cari thread-in unikal identifikatorunu (ID) əldə edir.
Thread.GetCurrentThread().IsBackground - Cari thread-in background olub olmadığını göstərir.
Thread.Start() - Thread-i işə salır.
Thread.Join() - Çağıran thread-i çağırılan threadin bitməsini gözləyir və sonra işə davam edir.
Thread.Interrupt() - Thread-i zorla dayandırır.

Thread-a biz Action və ya ParameterizedThreadStart delegate-ləri vasitəsilə metod ötürə bilərik. Yəni bu methodlar void qaytarmalı və parametr qəbul etməməlidir.
Thread əgər background thread-dirsə proqram bitdikdə avtomatik olaraq dayandırılır. Amma əgər foreground thread-dirsə proqram bitdikdə də işləməyə davam edir.
Yəni bizim programımız sonuncu foreground thread bitənə qədər işləməyə davam edir.
Thread-lərin prioritetləri də var. Prioritet nə qədər yüksəkdirsə thread o qədər tez işlənir. Yəni schedulerə threadin daha vacib olduğunu bildirir və nəticədə daha tez işlənir.
 
 

                                                                                ThreadPool

Timer classında biz baxdıq ki bir thread ui-ı bir thread isə timer-i idarə edir. Yəni iki thread var idi. Və buda bizə donmadan düzgün işləyən bir timer göstərirdi.

Bunun səbəbidə ThreadPool-dur.
ThreadPool - Thread hovuzu - Əməliyyat sistemi tərəfindən idarə olunan və müəyyən sayda thread-lərin saxlandığı bir hovuzdur.   

Hər bir project yaranan zaman inunla bərabər bir ThreadPool yaranır ki daxilində işləməyə hazır thread-lər saxlanılır.
Biz code daxilində Thread yaradıb işə salmaq əvəzinə ThreadPoola müraciət edirik və ThreadPool bizə işə hazır thread verir.
İşimiz bitdikdən sonra da istifadə etdiyimiz thread və ya threadlar yenidən ThreadPool-a qaytarılır ki yenidən istifadə olunsun.
Amma diqqət olunmalı məsələlərdən biri budur ki, Windows və .NET CLR-in öz ThreadPool-ları var. Biz code-muzda .NET-in ThreadPool-dan istifadə edirik.
İndi gəlin code nümunəsinə baxaq:

1. ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads) - İstifadə edilməyə hazır threadlərin sayını əldə edir.
Burada biz iki dəyər alırıq. workerThreads - ThreadPool-da olan əlçatan Threadların sayıdır, completionPortThreads - Bu isə sırf I/O əməliyyatları üçün nəzərdə tutulmuş thread-lərin sayıdır.
Burada aldığımız dəyərlər kompyuterlərdən asılı olaraq dəyişə bilər.
 
2. ThreadPool.QueueUserWorkItem() - Bu methodla biz ThreadPool-a iş göndəririk ki o iş üçün bir thread ayırsın və həmin thread işimizi görsün.
WaitCallback delegate-i vasitəsilə bir method ötürürük ki həmin method void qaytarmalı və bir object parametr qəbul etməlidir.
Bu methoda biz ya Action delegate-i ötürə bilərik ya da ParameterizedThreadStart delegate-i ötürə bilərik. 
void SomeOperation(object state)
{
    Console.WriteLine("Some operation is running...");
    Thread.Sleep(2000); // Simulate some work
    Console.WriteLine("Some operation is completed.");
}
ThreadPool.QueueUserWorkItem(SomeOperation); // SomeOperation methodunu ThreadPool-a göndərir.
Və bizdə SomeOperation methodu üçün ThreadPool-dan bir thread ayrılır və həmin thread işimizi görür.

Diqqət olunmalı bir digər məsələdə odurki ThreadPool-da yerləşən BÜTÜN threadlar background thread-lərdir. Yəni proqram bitdikdə avtomatik olaraq dayandırılırlar.

ThreadPool üstünlüyü:
1.Resurce Management - Resursların idarə olunması - ThreadPool resursları effektiv şəkildə idarə edir və lazımsız thread yaradılmasının qarşısını alır.
2.Performance - Performans - ThreadPool istifadə edərək thread yaratmaq və idarə etmək daha sürətlidir, çünki mövcud thread-lərdən istifadə olunur.
3.Yeni bir obyekt yaratmağa ehtiyyac olmur.
4.ManageMent - İdarəEtmə - ThreadPool özü idarə olunur diyə biz müdaxilə edə bilmirik.

Amma ThreadPool Thread-i böyük işlər zamanı yeni bir obyekt yaranmır və hazır threadlardan istifadə edir amma bu threadlarda əgər bir iş gedərsə bu zaman digər 
işlər threadin boşalmasını gözləyir buda bizə vaxt itkisinə səbəb olur. Burada söhbət on minlərlə və ya daha bğyük datalarla işlərdən gedir ki bu zaman düşünsək ki ThreadPool 10 və ya 20 Thread ayırıb ki bu dataları işləsin
bu zaman hiss olunan şəkildə vaxt itkisi və gecikmə baş verir. Amma Thread hər bir iş üçün bir Thread yaranır və buda gözləmə olmadan gecikməsiz və vaxt itkisiz işimiz həll olunur.
Diqqət edilməli hissə odur ki bu fərq sadəcə böyük processlərdə olur Yəni daha kiçik işlərdə ThreadPool böyük işlərdə isə Thread daha səmərəlidir.

İndi gəlin digər bir məsələyə nəzər yetirək:

void OtherOperation()
{
    Console.WriteLine("Other operation running")
    Thread.Sleep(2000); // Simulate some work
    Console.WriteLine("Other operation is completed.");
}
Biz bu methodu ThreadPoolumuza göndərə bilmirik çünki error alınır. Bu methodda return deyilsə və ya delegate-ə uyöun gəlmirsə
ThreadPool.QueueUserWorkItem(OtherOperations) - yazılışı error verir. amma
ThreadPool.QueueUserWorkItem(state=>{OtherOperation()}) - bu code blokunda biz state adında yeni bir obyekt yaradırıq ki bu obyektdə öz daxilində bizim yazdığımız methodu çağırır.



ThreadPool-un istifadə sahələri:

1. Class ThreadPool
2. WinForm Timer classes
3. Asinxron methodlar
4. TPL - Task Parallel Library



                                                                        Albahari tricks
Code 1:
for (int i = 0; i < 10; i++)
{
    new Thread(() =>
    {
        Console.WriteLine(i);
    }).Start();
}
Burada normalda gözlənilən nəticə düzgün olmayan sıra ilə 0-9-a qədər olan ədədlərin çıxmasıdır.
Amma belə olmur. Burada səbəb Threadların for dövründə olan i dəyərini daha sürətli almasıdır buda i-nin hər hansı bir dəyərində olan zaman
bu dəyərin bir və ya bir neçə dəfə əldə olunmasıdır. Çünki for dövründə hər i dəyərində 3 process gedir ki buda müəyyən bir zaman dilimi çəkir. Threadlarında daha sürətli
olduğuna görə bir qlobal dəyişən olan i dəyərini fərqli fərqli götürməsinə gətirib çıxarır. Thread daxilində əldə olunan i dəyəri capture list ilə alınan bir dəyər sayılır.
Capture List method daxilində istifadə olunacaq parametrlərin saxlandığı hissədir C++da. Amma C#-da bu class daxilində özü icra olunur və buna ehtiyyac olmurki bizdə parametrli obyekt göndərə bilirik bunun üçündə 
functor istifadə olunur ki () overloading olunur və class özünü method kimi apara bilir.
Bu problemin həlli üçün:

for (int i = 0; i < 10; i++)
{
    int x = i; // Burada bir x dəyişəni generasiya olunur və i dəyərinə bərabərləşdirilir ki buda bizə qeyri müəyyən sırada 0-9 aralığında ədədlər ekrana çıxır.
    new Thread(() =>
    {
        Console.WriteLine(x);
    }).Start();
}

Digər bir trick-ə baxaq

string name = "Huseyn";
Thread thread1 = new(() =>
{
    Console.WriteLine(name);
});
name = "Ensar";

Thread thread2 = new(() =>
{
    Console.WriteLine(name);
});

thread1.Start();
thread2.Start();

Bu code nümunəsində də biz görürük ki yenə də Threadlarımız qlobal dəyişənin real dəyərini əldə edir. Burada da eyni data ekrana çıxacaq çünki burada data qlobal olması səbəbilə Threadlar
real dəyəri əldə edir və onu istifadə edir.



                                                                                        Critical Section

Critical Section - Threadların eyni bir yaddaş sahəsinə(resursa) müraciət etməsinə deyilir.


Thread[] threads = new Thread[5];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() =>
    {
        for (int j = 0; j < 1000000; j++)
        {
            Counter.count++;
        }
    });
}
for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}

Console.WriteLine(Counter.count);
class Counter
{
    public static int count = 0;
}


Burada biz yazdığımız kodun 5 000 000 nəticəsini görəcəyimizi düşünürük çünki 5 000 000 toplama əməliyyatı olur. Amma burada bir nüans var.
Yazılan Counter.count++ əməliyyatı atomar əməliyyat deyil. Burada code hissəsi 3 əməliyyatdan ibarətdir. 
Counter.count = Counter.count + 1; İlk öncə əməliyyat yaddaşımızdan dəyişənin dəyəri alınır sonra artırılır və sonra isə bərabərləşdirilir. Bu səbəbdən bu dəyişənə Threadlar sürətli 
iş görmək üçün yarışdıqlarını nəzərə alaraq hər dəfə bu increment əməliyyatı bitmir və az dəyərlərə müraciət olunur. 
Bu uzun əməliyyatları atomar formata çevirmək üçün biz Interlocked classı istifadə olunur.

Thread[] threads = new Thread[5];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() =>
    {
        for (int j = 0; j < 1000000; j++)
        {
            Interlocked.Increment(ref Counter.count); // Interlocked classsının daxilində bəzi hazır methodlardan istifadə edərək bu hissəni atomar bir processə çeviririk və scheduler-a deyirik ki bu əməliyyat bitmədən hazırda işləyən Threadi çıxarmasın.
        }
    });
}
for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}
for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

Console.WriteLine(Counter.count);
class Counter
{
    public static int count = 0;
}


Amma biz şərt qoyaraq əməliyyatı icra etmək istəsək bu zaman digər bir problem çıxır ki buda Interlocked classının şərt qoymaq üçün olan methodlarının olmamasıdır. Gəlin code nümunəsində baxaq:
Qeyd edək ki Interlocked classımız sadəcə dəyişən üzərində əməl icra etmək üçün istifadə olunur və bu yoxlama işləri onun məsuliyyətində sayılmır.




Thread[] threads = new Thread[5];

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() =>
    {
        for (int j = 0; j < 1000000; j++)
        {
            Interlocked.Increment(ref Counter.count); // Interlocked classsının daxilində bəzi hazır methodlardan istifadə edərək bu hissəni atomar bir processə çeviririk və scheduler-a deyirik ki bu əməliyyat bitmədən hazırda işləyən Threadi çıxarmasın.
            if (Counter.count % 2 == 0) Interlocked.Increment(ref Counter.even); // Burada bu əmməliyyatımız atomar deyil çünki burada yoxlama zamanı dəyər başqa hissədədə eyni dəyər olarsa bu zaman səhv olur və Interlocked bu hissəni həll edə bilmir.
        }
    });
}
for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}
for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

Console.WriteLine(Counter.count);
class Counter
{
    public static int count = 0;
    public static int even = 0;
}
Bu hissənidə biz Monitor classından istifadə edirik


Thread[] threads = new Thread[5];
Object obj = new Object(); // Bu objectdə bizim block zamanı hansı 

for (int i = 0; i < threads.Length; i++)
{
    threads[i] = new Thread(() =>
    {
        for (int j = 0; j < 1000000; j++)
        {
            //Monitor.Enter(obj); // Bu method özündən sonra yazılan bütün hissəni ümumi bir əməliyyat kimi təyin edir və bu code blokunun icrasından sonra digərləri icra olunur. Bir növ bloklayır.
            //try
            //{
            //    Interlocked.Increment(ref Counter.count); // Interlocked classsının daxilində bəzi hazır methodlardan istifadə edərək bu hissəni atomar bir processə çeviririk və scheduler-a deyirik ki bu əməliyyat bitmədən hazırda işləyən Threadi çıxarmasın.
            //    if (Counter.count % 2 == 0) Interlocked.Increment(ref Counter.even); // Burada bu əmməliyyatımız atomar deyil çünki burada yoxlama zamanı dəyər başqa hissədədə eyni dəyər olarsa bu zaman səhv olur və Interlocked bu hissəni həll edə bilmir.
            //}
            //finally
            //{
            //    Monitor.Exit(obj); // Bu hissə bitəndən sonrada bu method istifadə olunur ki digər methodlarda istifadə olunsun.
            //}
            // Gəlin bu uzun hissənin birdə qısa yazılışına baxaq(syntax sugar):
            lock (obj)
            {
                Counter.count++;
                if(Counter.count%2==0) Counter.even++;
            }


        }
    });
}
for (int i = 0; i < threads.Length; i++)
{
    threads[i].Start();
}
for (int i = 0; i < threads.Length; i++)
{
    threads[i].Join();
}

Console.WriteLine(Counter.count);
class Counter
{
    public static int count = 0;
    public static int even = 0;

}









 
 
 
 
 
 
 
 
 
 
 
 
























































































 */