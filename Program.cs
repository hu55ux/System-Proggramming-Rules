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

                                                                                        Mutex 

Mutex - Mutual Exclusion (Qarşılıqlı istisna) - Internal və External Thread-ların iş zamanı birinin bloklanması vasitəsilə bir-birini gözləməsi processidir.
Mutex classı WaitHandle- classından törəyibki bu class vasitəsilə biz idarə olunmayan code bloklarını da istifadə edə bilirik.


#region Internal Mutex  
Mutex mutex = new Mutex();
int number = 1;

for (int i = 0; i < 5; i++)
{
    Thread thread = new(Count);
    thread.Name = $"Mister {i + 1}";
    thread.Start();
}

void Count()
{
    mutex.WaitOne(); // Bu hissə muteximizi bloklayır ki bu hissədə olan code hissəsi işini bitirməmiş digər işlər gedə bilməz.
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId}: {number++}");
    }
    mutex.ReleaseMutex(); // Bu hissədə də biz mutexi azad edirik ki artıq növbəti işə Thread-ə keçid etsin.
}

#endregion
 

#region External (global) Threads

string mutexName = "Mutex"; // Mutex classında IDisposable interface-dən realization olunduğuna görə using statement ilə istifadə oluna bilir. Və biz muteximizə ad verdiyimiz zaman bu External Mutex hesab olunur.

using (Mutex mutex = new Mutex(false,mutexName)) // Burada sadəcə mutexName verməklə biz bu mutex-in External Threadlar ilə işləməsini təmin edir. Burada olan bool dəyər isə true olarsa sadəcə işlədiyi hissəni görür və ilk hissə bitən zaman bu hissə ölür. Amma false olan zaman isə bu digər processləridə görür.
{
    if (!mutex.WaitOne(30000)) // Bu hissə əgər işləyən bir Thread varsa və digər Threadlar bu işləyən Threadi max gözləmə müddəti təyin olunur. Yəni göszləyən Thread 30 saniyə içəridəki Threadi gözləyir sonra isə gözləmir.
    {
        Console.WriteLine("Other Thread running"); // Burada WaitOne methodu bool dəyər qaytarır ki bu əgər işləyən varsa false qayıdır və bizdə true edərək bu kod hissəsini işlədirik. Əksində isə bu kod hissəsinə daxil olmur.
        Thread.Sleep(1000);
        return;
    }
    else
    {
        Console.WriteLine("My code running");
        Console.ReadKey();  
        mutex.ReleaseMutex();
    }
}


#endregion

Lock Monitor və Mutex hər biri Internal Threadlar ilə işləyə bilir. Amma fərqi buradadır ki Mutex həmdə External Threadlar ilə də işləyə bilir ki buda onun üstünlüyünü bildirir. 
Performans baxımından daha ağırdır (Lock/Monitor-dan yavaşdır).
Yanlış istifadə olunarsa deadlock (kilidlənmə) yarana bilər.
Çox tez-tez istifadə olunarsa proqramın sürəti ciddi azalır.



 
                                                                                        Semaphore və SemaphoreSlim

Semaphore - Semaphore – eyni anda məhdud sayda thread-in (axının) bir resursa girişinə icazə verən sinxronizasiya mexanizmidir.

Fərqi Mutex/Lock-dan odur ki, onlar yalnız 1 thread-ə icazə verir. Semaphore isə birdən çox (amma sayla məhdud) thread-in daxil olmasına icazə verə bilər.


#region Semaphore

Semaphore semaphore = new(3, 3); // Burada ilk dəyər Critical Sectionda başlanğıcda neçə icazənin mövcud olduğunu ikinci dəyər isə Semaphore-un maximum neçə Thread - ə icazə verə biləcəyini bildirir.
// Əgər biz burada Semaphore(1,1) yazsaq bu Mutex və ya Lock-dan fərqlənməyəcək çünki sadəcə bir threada icazə verəcək ki burada da heç bir fərq olmayacaq.
for (int i = 0; i < 10; i++)
{
    ThreadPool.QueueUserWorkItem(Some,semaphore);
}
Console.ReadKey();

void Some(object? state)
{
    Random random = new Random();
    var s = state as Semaphore;
    bool st = false;
    while (!st)
    {
        if (s.WaitOne(500))
        {
            try
            {
                Thread.Sleep(1);
                Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} take key.");
                Thread.Sleep(random.Next(3000, 6000));
            }
            finally
            {
                Thread.Sleep(1);
                st = true;
                Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} return key.");
                s.Release(); // Burada da işini bitirən thread azad olunması siqnalı göndərilir.
            }
        }
        else
        {
            Thread.Sleep(1);
            Console.WriteLine($"Mr. {Thread.CurrentThread.ManagedThreadId} sorry no key yet.");

        }
    }
}

#endregion


Və sadəcə üçüncü parametr olaraq bir string Name parametri verərək biz External Thread- ilə işləməsini təmin edirik.

SemaphoreSlim - Eyni Semaphore ilə işləyir amma sadəcə internal Threadlar ilə işləyir. Və IDisposable interface-indən törəyib və öz daxilində Waithandle istifadə edir.

Burada biz Release ilə siqnal göndəririk ki digər işləməyən threadlarda işləyə bilər Buna görə də:
Semaphore və SemaphoreSlim siqnallama mexanizmi sayılır.
Mutex və Lock isə blocklama mexanizmi sayılır.



AutoResetEvent - Bir siqnallama mexanizmidir ki, burada əgər critical section boşdursa bir Thread buraxılır və WaitOne müthodu ilə bloklanır Set methodu ilə isə blok açılır və digər thread - i içəri buraxır
Bu event çox istifadə olunan bir code hissəciyi deyil. Çünki bu spaghetti code sayılır və bu cür code hissəsidə istifadəyə uyğun deyil. Sadəcə istisna hallarda istifadə oluna bilər.

// AutoResetEvent - siqnallama mexanizmi

AutoResetEvent _workEvent = new AutoResetEvent(false);
AutoResetEvent _mainEvent = new AutoResetEvent(false);

// 1. start
Thread thread = new(() =>
{
    SomeProcess(1);
});
thread.Start();
Console.WriteLine("Waiting Some Process");
// 1. End

_workEvent.WaitOne(); // Burada bu hissə bloklanır.

// 3. Start
Console.WriteLine("Starting Main Process");

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"Main proces - {i}");
    Thread.Sleep(TimeSpan.FromSeconds(1));
}
// 3. End
Console.ReadLine();
_mainEvent.Set(); // mainEventə siqnal göndərilir

Console.WriteLine("Worker doing some job");

_workEvent.WaitOne(); // Burada da siqnal gözlənilir.

// 5. start
Console.WriteLine("Complete");
// 5. end



void SomeProcess(int seconds)
{
    // 2. Start
    Console.WriteLine("Starting some process");
    Thread.Sleep(TimeSpan.FromSeconds(seconds));
    Console.WriteLine("Ok");
    // 2. End

    Console.ReadLine();
    _workEvent.Set(); // _workEvent - in bloklandığı hissəyə qayıdırıq və onu davam etdiririk.

    Console.WriteLine("Main process is working");
    _mainEvent.WaitOne(); // Buradada mainEvent bloklanıb və siqnal gözləyir

    // 4. Start
    for (int i = 0; i < 10; i++)
    {
        Console.WriteLine($"Some process - {i}");
        Thread.Sleep(TimeSpan.FromSeconds(i));
    }
    Console.WriteLine("Some Process End");
    // 4. End

    Console.ReadLine();
    _workEvent.Set(); // Burada da siqnal göndərilir.
}


AutoResetEvent – turniket (hər kart basanda yalnız 1 nəfər keçir, sonra bağlanır).
ManualResetEvent – darvaza (açsan, hamı keçir, sən bağlayana qədər).
 
 
 
Code-un necə bloklanıb bloklanmadığını system necə təyin edir. İlk öncə bildiyimiz kimi Hər bir datanın arxa planda onunla bağlı ətraflı digər məlumatlar saxlanılır. Bu dataların hesabına CLR code-muzu daha səliqəli və rahat idarə edir.
Bu objectlərdə bir SyncBlockIndex adlı bir dəyişən var ki buda əgər bloklanmazsa yəni default mənfi bir dəyər olur. amma əgər bloklanarsa burada 0-dan başlayan bir index yaranır.


Deadlock — proqramlaşdırmada (xüsusilə paralel işləyən thread-lərdə) iki və ya daha çox işçi (thread) bir-birini gözlədiyi üçün heç vaxt davam edə bilmədiyi vəziyyətdir.



object lockA = new object();
object lockB = new object();

static void Main()
{
    Thread t1 = new Thread(Thread1Work);
    Thread t2 = new Thread(Thread2Work);

    t1.Start();
    t2.Start();

    t1.Join();
    t2.Join();
}

void Thread1Work()
{
    lock (lockA)
    {
        Console.WriteLine("Thread 1: lockA götürüldü");
        Thread.Sleep(100); // vaxt itkisiylə başqa thread-in işə düşməsinə imkan verir

        lock (lockB)
        {
            Console.WriteLine("Thread 1: lockB də götürüldü");
        }
    }
}

void Thread2Work()
{
    lock (lockB)
    {
        Console.WriteLine("Thread 2: lockB götürüldü");
        Thread.Sleep(100);

        lock (lockA)
        {
            Console.WriteLine("Thread 2: lockA da götürüldü");
        }
    }
}
}






RTTI - (Run Time Type Information) - C#-da Obyektin icra zamanı real tipini öyrənmək üçün istifadə olunan mexanizmdir.
Kompilyasiya zamanı tip məlum deyil (xüsusilə polimorfizmdə).
RTTI icra zamanı obyektin həqiqi tipini müəyyən edir.

Nə zaman istifadə olunur?
1. Polimorfizm zamanı obyektin real tipini tapmaq.
2. Casting zamanı səhv çevirmədən qaçmaq.
3. Logging, debugging üçün tip məlumatı almaq.
4. Reflection ilə plugin, serialization və dinamik sistemlər yaratmaq.

C#-da sadə analoq
1. Təsəvvür et ki, sənin əlin “Heyvan” qutusundadır.
2. Amma içində əslində it, pişik və ya quş ola bilər.
3. RTTI bizə deyir: “Bu qutunun içində əslində nə var?” 

Yekun
C#-da RTTI əsasən:
1. GetType() → tipin adı
2. is → tip yoxlama
3. as → təhlükəsiz çevirmə
4. Reflection → dərin tip məlumatı
🔹 Qısa desək: RTTI = obyektin icra zamanı real tipini öyrənmək mexanizmidir.




                                                                                    Concellation Token

Concellation Token - Biz token deyən zaman bir bilet və ya açar kimi tərcümə edirik. Code-da da bu bir mexanizmdir ki müəyyən hissələrə giriş imkanı verilir.
Token-in bloklanmasının yəni ThreadPool Threadinin işinin dayandırılmasının iki növü var. Bunlar Soft(return ilə) və Hard(Exception ilə) olaraq iki hissəyə bölünür.
*/
#region Soft version

//using CancellationTokenSource cts = new(); // İlk olaraq CancellationTokenSource obyektini yaradırıq. 
//// Bu obyekt sayəsində biz istədiyimiz vaxt başqa thread-ə "dayan" siqnalı göndərə biləcəyik.

//CancellationToken cancellationToken = cts.Token; // CancellationTokenSource içindən Token alırıq. 
//// Bu token başqa methodlara göndəriləcək ki, onlar dayandırılma siqnalını yoxlaya bilsin.

//ThreadPool.QueueUserWorkItem(o =>
//{
//    Download(cancellationToken);
//});
//// ThreadPool-da yeni iş (task) başladırıq və 
//// həmin işdə "Download" metodunu çağırırıq, 
//// Token-i də parametr kimi ötürürük.

//var key = Console.ReadKey();
//// İstifadəçidən klaviaturadan düymə girişi gözləyirik.

//if (key.Key == ConsoleKey.Enter)
//{
//    cts.Cancel();
//    Thread.Sleep(1000);
//    Console.WriteLine("Downloading process canceled..");
//}
//// Əgər istifadəçi Enter düyməsinə basarsa, 
//// cts.Cancel() çağrılır → bu, Token-i "işi dayandır" vəziyyətinə gətirir. 
//// Sonra 1 saniyə gözləyirik və istifadəçiyə prosesi dayandırdığını bildiririk.

//Console.ReadKey();
//// Proqram sonunda yenidən istifadəçidən düymə gözləyir ki, konsol bağlanmasın.

//void Download(CancellationToken cancellationToken)
//// Download metodunu yazırıq və Token parametr olaraq qəbul edilir.

//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);
////    Əvvəlcə ekrana "start" yazırıq və 1 saniyə gözləyirik.

//    for (int i = 0; i < 100; i++)
//    {
//        if (cancellationToken.IsCancellationRequested) return;
////        Əgər token işarələnibsə (Cancel olunubsa), 
////        metodu dərhal dayandırırıq (return).

//        Console.WriteLine($"{i}%");
//        Thread.Sleep(1000);
//        Console.Clear();
////        Əks halda dövr davam edir: faiz göstərilir, 1 saniyə gözlənilir və ekran təmizlənir.
//    }

//    Console.WriteLine("Download process completed..");
////    Əgər for dövrü bitdisə, deməli yükləmə uğurla tamamlanıb.
//}

#endregion

#region CancellationToken with exception
//using CancellationTokenSource cts = new();
//// CancellationTokenSource obyektini yaradırıq. Bu bizə "cancel" siqnalı vermək imkanı verir.

//CancellationToken cancellationToken = cts.Token;
//// cts içindən Token alırıq, bu token başqa thread-lərdə istifadə ediləcək ki, 
//// "işi dayandırmaq lazımdırmı?" sualına cavab versin.

//ThreadPool.QueueUserWorkItem(o =>
//{
//    try
//    {
//        Download(cancellationToken);
//        // ThreadPool-da yeni iş başladırıq. Bu iş "Download" metodunu icra edir. 
//        // Token də metodun içində istifadə olunacaq.
//    }
//    catch (OperationCanceledException ex)
//    // Əgər token "cancel" olarsa və metod ThrowIfCancellationRequested() atarsa,
//    // OperationCanceledException atılacaq.
//    {
//        Console.WriteLine(ex.Message);
//        Console.WriteLine("Downloading process cancel!");
//        // İstifadəçiyə məlumat veririk ki, proses dayandırıldı.
//    }
//});

//var key = Console.ReadKey();
//// İstifadəçidən hər hansı düyməyə basmasını gözləyirik.

//if (key.Key == ConsoleKey.Enter)
//// Əgər Enter düyməsinə basılıbsa:
//{
//    cts.Cancel();
//    // Token-ə "dayandır" siqnalı göndəririk.
//    Thread.Sleep(1000);
//    // Kiçik gözləmə veririk ki, digər thread dayandırılsın.
//}

//Console.ReadKey();
//// Konsol bağlanmasın deyə yenidən düymə gözləyirik.

//void Download(CancellationToken token)
//// Yükləmə prosesini imitasiya edən metod.
//{
//    Console.WriteLine("Downloading start...");
//    Thread.Sleep(1000);

//    for (int i = 0; i < 100; i++)
//    {
//        token.ThrowIfCancellationRequested();
//        // Əgər token cancel olunubsa → buradan OperationCanceledException atılacaq.
//        // Bu da try/catch blokunda tutulacaq.

//        Console.WriteLine($"{i}%");
//        // Faiz dəyərini ekrana yazırıq (yüklənmə göstəricisi).

//        Thread.Sleep(100);
//        // Kiçik gecikmə → yüklənmə real kimi görünsün.

//        Console.Clear();
//        // Ekranı təmizləyirik ki, faiz yeniləndikcə səliqəli çıxsın.
//    }

//    Console.WriteLine("Downloading end...");
//    // Əgər dövr tam bitdisə, deməli yükləmə uğurla tamamlanıb.
//}

#endregion
/*

                                                                                TPL - Task Parallel Library

Task Parallel Library - Asinxron programlaşdırmanın bir hissəsidir və arxa planda ThreadPool istifadə olunur. Thread və ThreadPooldan üstünlüklərindən biri dah çox hazır methodlarının olmasıdır ki 
bu methodlarda bizə daha çox idarəetmə imkanı verir. Task daxilinde işləyən Threadlar Backgrpund thread-dir.
Task daxilinə Action və CancellationToken göndərə bilərik.
*/

#region Task Creating running

//// Task1 -> Sadə Task obyekti yaradılır, amma hələ başlamır
//Task task1 = new Task(() =>
//{
//    TaskMethod("Task1"); // Task icra olunanda bu metod çağırılacaq
//});
//// Task2 -> Task1 ilə eyni, sadəcə adı fərqlidir
//Task task2 = new Task(() =>
//{
//    TaskMethod("Task2");
//});
//// Task3 -> Task.Run istifadə olunur, Task həm yaradılır, həm də dərhal işə düşür
//Task task3 = Task.Run(() =>
//{
//    TaskMethod("Task3");
//});
//// Task4 -> Task.Factory.StartNew istifadə olunur, bu da həm yaradıb həm dərhal işə salır
//Task task4 = Task.Factory.StartNew(() =>
//{
//    TaskMethod("Task4");
//});
//// Task5 -> Task yaradılır, amma əlavə olaraq LongRunning flag verilmişdir
//// Bu, uzun müddətli task olduğunu bildirir və çox vaxt ThreadPool əvəzinə ayrı bir thread açılır
//Task task5 = new Task(() =>
//{
//    TaskMethod("Task5");
//}, TaskCreationOptions.LongRunning); // Bu hissə bir enum-dır ki yaranma formasını təyin edirik.
//// ---------------- TASK-ların işə salınması ----------------
//task1.Start(); // Task1 əvvəldən başlamamışdı, indi işə düşür
//task2.Start(); // Task2 də Start() ilə işə düşür
//task5.Start(); // Task5 də Start() ilə işə düşür
//// task3 və task4 artıq yaradılan anda işə düşdüyünə görə Start() lazım deyil
//// ---------------- TASK-ların tamamlanmasını gözləmək ----------------
//task1.Wait(); // Task1 bitməyənə qədər gözləyir
//task2.Wait(); // Task2 bitməyənə qədər gözləyir
//task3.Wait(); // Task3 bitməyənə qədər gözləyir
//task4.Wait(); // Task4 bitməyənə qədər gözləyir
//task5.Wait(); // Task5 bitməyənə qədər gözləyir
////Console.ReadLine(); // Əlavə olaraq proqramın bağlanmaması üçün istifadə oluna bilər
//// ---------------- TASK-ların çağırdığı metod ----------------
//void TaskMethod(string message)
//{
//    Console.WriteLine($@"
//Name:           {message}                          // Hansi Task olduğunu göstərir
//Id:             {Thread.CurrentThread.ManagedThreadId}   // Hansi thread üzərində icra olunur
//IsBackground:   {Thread.CurrentThread.IsBackground}       // Thread background-durmu?
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread} // ThreadPool-dandırmı, yoxsa ayrıca thread-dir?
//");
//}

#endregion

#region Returning
// Taskın əsas üstünlüyü də dəyər return edə bilməsidir ki bu da Thread və ThreadPool-un edə bilmədiyi məsələdir.
// Void Task olan zaman biz sadə Task istifdə edə bilərik amma əgər Task bir dəyər return edirsə Generic Task istifadə olunmalıdır.

//Task<int> task = Task.Run(() => TaskReturnMethod("Task1", 3));


//var result = task.Result; // Burada yazdığımız Result hissəsi dəyər qaytarmaqla birlikdə Join işini görür ki buda Taskın və programın dəyər qaytarılmamış bitməməsinin qarşısını alır.

//Console.WriteLine(result);


//int TaskReturnMethod(string message, int second)
//{
//    Console.WriteLine($@"
//Name:           {message}
//Id:             {Thread.CurrentThread.ManagedThreadId}
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
//");
//    Thread.Sleep(TimeSpan.FromSeconds(second));
//    return second * 10;
//}


#endregion

/*




                                                                            Continuations 

Continuations - Davametmələr - Task bitərsə, exception atarsa və ya dayandırılarsa işləyəcək code blockudur.
Continuations-ın 5 əsas növü var:
1. Simple Continuation - Sadə davametmə - Bir Task bitir və bir method işə düşür.
2. ContinueWhenAll - Bütün Tasklar bitdikdən sonra davam edir.
3. Multiple Continuation - Çoxlu davametmə - Bir task bitdikdə bir neçə method işə düşür.
4. ContinueWithAny - bir neçə Task qrupundan hər hansı bir task bitdikdə işə düşən method.
5. Continuation with child Task - İç içə Tasklar olan zaman bütün daxildə olan Tasklar öz işlərini görür və sonra bu method işə düşür.

*/
#region Continue with OnlyRunToCompletetion
//// Bu region kodu qruplaşdırmaq üçündür (IDE-də rahatlıq üçün).
//// İki Task<int> yaradılır, amma hələ başlamır
//var firstTask = new Task<int>(() => TaskMethod("First Task", 3));  // 3 saniyə işləyəcək
//var secondTask = new Task<int>(() => TaskMethod("Second Task", 5)); // 5 saniyə işləyəcək
//// ------------------- firstTask üçün ContinueWith -------------------
//firstTask.ContinueWith(t =>
//{
//    Console.WriteLine("Continue With task start.");   // firstTask bitəndən sonra işə düşür
//    Console.WriteLine($"Task Result = {t.Result}");   // firstTask nəticəsini çap edir
//    Console.WriteLine($@"
//Id:             {Thread.CurrentThread.ManagedThreadId}          // İcra olunan thread Id-si
//IsBackground:   {Thread.CurrentThread.IsBackground}             // Thread background-durmu?
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}       // ThreadPool-dandırmı?
//");
//}, TaskContinuationOptions.OnlyOnRanToCompletion);
//// Bu continuation yalnız firstTask uğurla bitəndə işləyəcək 
//// (yəni faulted və ya canceled olmayanda)
//// ------------------- firstTask işə salınır -------------------
//firstTask.Start();
//// Main thread öz işinə davam edir (asinxron icra görünsün deyə dövr yazılıb)
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main method - {i}"); // Əsas metodun axını davam edir
//    Thread.Sleep(10); // kiçik gecikmə
//}
//// ------------------- secondTask üçün ContinueWith -------------------
//secondTask.ContinueWith(t =>
//{
//    OtherMethod(); // Əgər secondTask uğurla bitdisə və ya cancel olmayıbsa, bu metod çağırılacaq
//}, TaskContinuationOptions.NotOnCanceled | TaskContinuationOptions.NotOnFaulted);
//// Burada şərt budur: secondTask nə canceled, nə də faulted olmamalıdır
//// ------------------- Task-ların gözlənməsi -------------------
//// firstTask və secondTask bitənə qədər main thread gözləyir
//Task.WaitAll(firstTask, secondTask);
//Console.WriteLine("End"); // Hamısı bitdikdən sonra ekrana yazılır
//// ------------------- Metodlar -------------------
//int TaskMethod(string message, int second)
//{
//    Console.WriteLine($"Task - {message} start"); // Task başladığını göstərir
//    Console.WriteLine($@"
//Id:             {Thread.CurrentThread.ManagedThreadId}          // Hansı thread-də işləyir
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
//");
//    Thread.Sleep(TimeSpan.FromSeconds(second)); // Göstərilən qədər saniyə gözləyir
//    Console.WriteLine($"Task - {message} end"); // Task bitdi mesajı
//    return second * 10; // Nəticə qaytarılır
//}
//void OtherMethod()
//{
//    Console.WriteLine("Other method start"); // Metod başladı
//    Console.WriteLine($@"
//Id:             {Thread.CurrentThread.ManagedThreadId}          // Hansı thread-də işləyir
//IsBackground:   {Thread.CurrentThread.IsBackground}
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}
//");
//    Console.WriteLine("Other method end"); // Metod bitdi
//}
#endregion

#region ContinueWith OnlyOnFaulted
//try
//{
//    // ------------------- Task yaradılır -------------------
//    var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//    // Bu Task int qaytarır, 3 saniyəlik işləyəcək
//    // ------------------- ContinueWith əlavə olunur -------------------
//    firstTask.ContinueWith(t =>
//    {
//        Console.WriteLine("ContinueWith task start"); // Əgər fault olarsa işləyəcək
//        Console.WriteLine($@"
//Id:             {Thread.CurrentThread.ManagedThreadId}          // Thread Id
//IsBackground:   {Thread.CurrentThread.IsBackground}             // Background thread?
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}       // ThreadPool üzərində işləyirmi?
//");
//    }, TaskContinuationOptions.OnlyOnFaulted);
//    // Bu continuation yalnız Task uğursuz (faulted) olarsa icra olunacaq
//    // Yəni Task-da exception atılsa, bu blok işləyəcək
//    // ------------------- Task işə salınır -------------------
//    firstTask.Start();
//    // Main thread öz işinə davam edir
//    for (int i = 0; i < 10; i++)
//    {
//        Console.WriteLine($"Main thread - {i}"); // Main thread dövr edir
//        Thread.Sleep(10); // kiçik gecikmə
//    }
//    // ------------------- Task-ın bitməsini gözləyirik -------------------
//    firstTask.Wait(); // firstTask tamamlanana qədər main gözləyir
//    Console.WriteLine("End"); // Task uğurla bitsə, proqram sonunda "End" yazır
//}
//catch (Exception ex)
//{
//    // Əgər Task-da və ya başqa yerdə exception atılsa,
//    // bu blokda tutulacaq
//    Console.WriteLine(ex.Message);
//}
//// Proqramın sonunda istifadəçi düymə basana qədər gözləyirik
//Console.ReadLine();
//// ------------------- Task-da çağırılan metod -------------------
//int TaskMethod(string message, int second)
//{
//    Console.WriteLine($"Task - {message} start"); // Task başladı
//    Console.WriteLine($@"
//Id:             {Thread.CurrentThread.ManagedThreadId}          // Hansı thread-də işləyir
//IsBackground:   {Thread.CurrentThread.IsBackground}             // Background-durmu?
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread}       // ThreadPool üzərində işləyirmi?
//");
//    Thread.Sleep(TimeSpan.FromSeconds(second)); // 3 saniyəlik gecikmə
//    Console.WriteLine($"Task - {message} end"); // Task bitdi
//    // Əgər burada exception atsaydıq (məsələn: throw new Exception("Xəta");),
//    // onda yuxarıdakı ContinueWith (OnlyOnFaulted) işə düşəcəkdi.
//    return second * 10; // Normal halda nəticə qaytarır
//}
#endregion

#region Continue with Task

//// Task yaradılır və içində TaskMethod çağırılır
//// Bu metod int qaytarır (ona görə Task<int>)
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//// ContinueWith: firstTask uğurla bitəndə icra olunacaq
//// TaskContinuationOptions.OnlyOnRanToCompletion → ancaq uğurla bitəndikdə işləyəcək
//// TaskContinuationOptions.LongRunning → davam işini yeni threaddə başlada bilər (ThreadPool-dan kənar)
//firstTask.ContinueWith(t =>
//{
//    Console.WriteLine("ContinueWith task start");
//    Console.WriteLine($@"
//Id:             {Thread.CurrentThread.ManagedThreadId}   // Hal-hazırki thread ID
//IsBackground:   {Thread.CurrentThread.IsBackground}      // Thread background olub-olmaması
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread} // ThreadPool thread-də işləyib-işləmədiyi
//");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.LongRunning);
//// Task start edilir
//firstTask.Start();
//// Main thread paralel olaraq işləyir
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10); // Kiçik gecikmə veririk
//}
//// firstTask bitənə qədər gözləyirik
//firstTask.Wait();
//Console.WriteLine("End");
//Console.ReadLine(); // Konsol açıq qalsın


//// TaskMethod: sadəcə simulyasiya üçün uzunmüddətli iş görür
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;

//static int TaskMethod(string name, int seconds)
//{
//    Console.WriteLine($"{name} started.");

//    for (int i = 0; i < seconds; i++)
//    {
//        Console.WriteLine($"{name} working... {i + 1} sec");
//        Thread.Sleep(1000); // 1 saniyəlik iş simulyasiyası
//    }

//    Console.WriteLine($"{name} finished.");
//    return seconds; // nəticə qaytarır
//}
#endregion

#region ContinueWith ExecuteSyncronously
//// Task yaradılır: TaskMethod çağırılacaq
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));

//// ContinueWith əlavə edirik
//// TaskContinuationOptions.OnlyOnRanToCompletion → yalnız uğurla bitəndə işləyəcək
//// TaskContinuationOptions.ExecuteSynchronously → davam işini mümkün olduqda
//// eyni thread üzərində icra edir (yeni thread açmır, daha sürətli olur)
//firstTask.ContinueWith(t =>
//{
//    Console.WriteLine("ContinueWith task start");
//    Console.WriteLine($@"
//Id:             {Thread.CurrentThread.ManagedThreadId}   // Hal-hazırki thread ID
//IsBackground:   {Thread.CurrentThread.IsBackground}      // Thread background olub-olmaması
//IsThreadPool:   {Thread.CurrentThread.IsThreadPoolThread} // ThreadPool-da işləyib-işləmədiyi
//");
//}, TaskContinuationOptions.OnlyOnRanToCompletion | TaskContinuationOptions.ExecuteSynchronously);

//// Task start edilir
//firstTask.Start();

//// Task tamamlanana qədər gözlənilir
//firstTask.Wait();

//Console.WriteLine("End");
//Console.ReadLine(); // Konsol bağlı qalmasın

#endregion

#region Task Status
// Bu işlər bitdikdə bizdə bir sual yarana bilər ki axı bu Task necə bilir ki o səhv edib çixib yoxsa bitib.
// Bu zaman bizə Task Status enum-ı yaranır və Task daxilində bu datalara uyğun bir siqnal göndərilir.
// 
/*
 Created
 WaitingForActivation
 WaitingToRun 
 Running
 WaitingForChildrenToComplete
 RanToCompletion
 Canceled
 Faulted
 
*/

//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//Console.WriteLine(firstTask.Status);
//Thread.Sleep(100);
//try
//{
//    Console.WriteLine(firstTask.Status);
//    firstTask.Start();
//    while (true)
//    {
//        Console.WriteLine(firstTask.Status);
//        Thread.Sleep(100);
//        if (firstTask.IsCompleted) break;
//    }
//    firstTask.Wait();
//    Console.WriteLine(firstTask.Status);

//}
//catch (Exception)
//{
//    Console.WriteLine(firstTask.Status);
//}
#endregion

/*





                                                                    Waitings

Waiting - Taskın hər işini bitirməsini gözləməsidir məsələn burada bir dəyər gözləmə və s ola bilər. 
3 əsas növü var.
1. Single Wait - Program sadəcə bir Taskın işini bitirməsini gözləyir 
1. Wait All - Bütün Taskların bitməsini gözləyir
1. Wait Any - Hər hansı bir Taskın bitməsini gözləyir
 
 */

#region Single Wait
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//firstTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}
////Console.WriteLine(firstTask.Result);
//firstTask.Wait();
//Console.WriteLine("Main end");
#endregion

#region Wait all
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//var secondTask = new Task<int>(() => TaskMethod("SecondTask", 3));
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}

//Task.WaitAll(firstTask, secondTask);
//Console.WriteLine("Main end");
#endregion

#region Wait any
//var firstTask = new Task<int>(() => TaskMethod("FirstTask", 3));
//var secondTask = new Task<int>(() => TaskMethod("SecondTask", 1));
//firstTask.Start();
//secondTask.Start();
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine($"Main thread - {i}");
//    Thread.Sleep(10);
//}

//Task.WaitAny(firstTask, secondTask);
//Console.WriteLine("Main end");
#endregion

#region Waiting child
//var grandFatherTask = new Task<int>(() => {

//    var fatherTask = Task.Factory.StartNew(() =>
//    {
//        var grandSonTask = Task.Factory.StartNew(() =>
//        {
//            TaskMethod("Grandson task", 8);
//        }, TaskCreationOptions.AttachedToParent);
//        TaskMethod("Father task", 5);
//    }, TaskCreationOptions.AttachedToParent);

//    return TaskMethod("GrandFather task", 3);
//});
//grandFatherTask.Start();
//Console.WriteLine(grandFatherTask.Result);
//Console.WriteLine("End");

#endregion

/*



                                                                Async Await

Biz asynchron programlaşdırmaya başlayan zaman ilk olaraq Thread - ThreadPool - Task keçmişik və bunlar bir birlərinin daha üstün formalarıdır.
İndi isə sıra - syntax sugar + love = async await öyrənəciyik və niyə məhz syntax sugar və love birləşməsi olmasını başa düşməyəçalışacağıq.

Asynchron yüklənmə zamanı bir neçə iş görülürsə bu zaman bir Message Queue yaranır ki burada işlər sıra ilə tənzimlənir və hər kəsin sırası ilə çıxır.
Buda bizə fərqli bir Thread iş görən Thred daxilində olan bir dataya daxil olmaq istəyərsə bu system ona icazə vermir.
Bunun üçündə biz task yaranan zaman sinxron işləməsini təmin etməliyik.

DİQQƏT !!!!!!!!!!!
Əgər bizim methodumuz async-dirsə bu zaman adlandırmada buna uyğun olmalıdır. Məsələn : async void SomeMethodAsync(){some code block};


var task = new Task(()=>
{
   some code parts 
}),TaskScheduler.FromCurrentSynchronizationContext();
 
 */
#region async await simple

//Console.WriteLine($"Main start in Thread : {Thread.CurrentThread.ManagedThreadId}"); // Main Thread
////SomeMethod();
//SomeMethodAsync();
//Console.WriteLine($"Main end in Thread : {Thread.CurrentThread.ManagedThreadId}"); // Main Thread
//Console.ReadKey();
//void SomeMethod()
//{
//    Console.WriteLine($"SomeMethod start in Thread : {Thread.CurrentThread.ManagedThreadId}"); // Main Thread
//    var result = Task.Run<int>(() =>
//    {
//        Console.WriteLine($"SomeMethod Task start in Thread: {Thread.CurrentThread.ManagedThreadId}"); // Some ThreadPool Thread
//        Thread.Sleep(1000);
//        Console.WriteLine($"SomeMethod Task end in Thread: {Thread.CurrentThread.ManagedThreadId}"); // Some ThreadPool Thread
//        return 77;
//    });
//    Console.WriteLine($"SomeMethod end in Thread : {Thread.CurrentThread.ManagedThreadId} Result:{result.Result}"); // Main Thread
//}
//async void SomeMethodAsync()
//{
//    Console.WriteLine($"SomeMethod start in Thread : {Thread.CurrentThread.ManagedThreadId}"); // Main Thread
//    var result = await Task.Run<int>(() =>
//    {
//        Console.WriteLine($"SomeMethodAsync Task start in Thread: {Thread.CurrentThread.ManagedThreadId}"); // Same ThreadPool Thread
//        Thread.Sleep(1000);
//        Console.WriteLine($"SomeMethodAsync Task end in Thread: {Thread.CurrentThread.ManagedThreadId}"); // Same ThreadPool Thread
//        return 77;
//    });
//    Console.WriteLine($"SomeMethod end in Thread : {Thread.CurrentThread.ManagedThreadId} Result : {result}"); // Same ThreadPool Thread 
//} // Burada yazılan tək async await keywordları bildirir ki result qaytarılan sətir elə Taskın işlədiyi Thread-da işini bitirir və buda bizə daha sürətli işləmə təmin edir.
#endregion

#region simple
WebClient webClient = new();
string url = @"https://turbo.az";
async void DownloadAsync()
{
    var text = await webClient.DownloadStringTaskAsync(url);
    Console.WriteLine(text);
}

#endregion

#region with return

//// Biz əgər async methodda dəyər return ediriksə bu zaman sadə Task-dan yox Generic Taskdan istifadə edirik


//async Task<string> SomeAsync(string url)
//{
//    return await webClient.DownloadStringTaskAsync(url);
//}

//var task = await SomeAsync(url); // Burada task yerinə birbaşa taskın resultunu almaq istəsək sadəcə await yazaraq həll edirik.
//Console.WriteLine(task);

#endregion

#region Inside async await
//Some some = new();
//some.SomeMethod();
//class Some
//{
//    public void SomeMethod()
//    {
//        Console.WriteLine($"Some method start in Thread: {Thread.CurrentThread.ManagedThreadId}");
//        Console.WriteLine("Some method begin");
//        Thread.Sleep(1000);
//        Console.WriteLine("SomeMethod end");
//    }

//    public void SomeMethodAsync()
//    {
//        AsyncStateMachine stateMachine = new AsyncStateMachine();
//        stateMachine.some = this;
//        stateMachine.builder= AsyncVoidMethodBuilder.Create();
//        stateMachine.state = -1;
//        stateMachine.builder.Start(ref stateMachine);
//    }
//}

//struct AsyncStateMachine : IAsyncStateMachine
//{
//    public int state;
//    public Some some;
//    private TaskAwaiter awaiter;
//    public AsyncVoidMethodBuilder builder;
//    public void MoveNext()
//    {
//        if (state == -1)
//        {
//            Console.WriteLine($"Start Thread ID : {Thread.CurrentThread.ManagedThreadId}");
//            Task t = Task.Factory.StartNew(some.SomeMethod);
//            awaiter = t.GetAwaiter();
//            state = 0;
//            builder.AwaitOnCompleted(ref awaiter, ref this);
//        }
//        else if (state == 0)
//        {
//            Console.WriteLine($"Start Thread ID : {Thread.CurrentThread.ManagedThreadId}");
//        }
//    }

//    public void SetStateMachine(IAsyncStateMachine stateMachine)
//    {
//        builder.SetStateMachine(stateMachine);
//    }
//}


#endregion


/*


                                                                    Parallel & PLINQ


 
 
*/

List<Student> students = new List<Student>();

for (int i = 0; i < 10; i++)
{
    students.Add(new Student()
    {
        Id = i + 1,
        FirstName = Faker.NameFaker.FirstName(),
        LastName = Faker.NameFaker.LastName(),
        Age = Faker.NumberFaker.Number(18, 75),
        Mark = Faker.NumberFaker.Number(10, 120) / 10.0,
        Email = Faker.InternetFaker.Email()

    });
}

#region Task When Continue

//var task1 = Task.Run(() =>
//{
//    for (int i = 0; i < students.Count / 2; i++)
//    {
//        students[i].Group = "FSDM_Oct_24_4_az";
//        Thread.Sleep(10);
//    }
//});

//var task2 = Task.Run(() =>
//{
//    for (int i = students.Count / 2; i < students.Count; i++)
//    {
//        students[i].Group = "FSDA_Oct_24_5_az";
//        Thread.Sleep(10);
//    }
//});
//
//Task.WaitAll(task1, task2);
//await Task.WhenAll(task1, task2, WriteDataLog(), SendEmailNotification(), SendSmsNotification()) // Bu hissədə də biz bu hissədə olan bütün işlər bitəndən sonra davam edəcək işi təyin edirik
//    .ContinueWith(t =>
//    {
//        Console.WriteLine("Continue with Task");
//    });
//Console.WriteLine("End");

//students.ForEach(Console.WriteLine);

//// Formal xarakterli methodlardır ki bunlar bizim bəzi işlərimizin olmasını realizasiya edir.
//Task WriteDataLog() => Task.Delay(500); 
//Task SendEmailNotification() => Task.Delay(200);
//Task SendSmsNotification() => Task.Delay(700);

#endregion

#region Parallel
/*
Əsas məqsədi adi for və foreach dövrələrini və ardıcıl metod çağırışlarını paralel (yəni eyni vaxtda bir neçə thread ilə) icra etməkdir.
Amma diqqət yetirməli olunan hissə Critical Section problemidir ki bunun da qarşısını Concurrent Collections istifadə olunması və ya istifadəçinin lock istifadəsidir ki 
Buradada məsuliyyət developer-ın üzərinə düşür. Çünki Parallel ThreadSafe deyil və bu da Critical Section probleminin əsas səbəbidir.
Parallel classı daha çox böyük və çoxsaylı datalarda və methodlarda istifadə olunur ki buda bizə performans üstünlüyü təmin edir. Əgər biz kiçik və azsaylı data ilə
işləyiriksə bu zamanda sadə for iləişləmək daha məqsədəuyğundur.
*/


//Parallel.For(0, students.Count, new ParallelOptions { MaxDegreeOfParallelism = 6 },
//    i =>
//    {
//        students[i].Group = "FSDM_Oct_24_4_az";
//        Console.WriteLine($"""
//            ThreadId:               {Thread.CurrentThread.ManagedThreadId}
//            IsBackground:           {Thread.CurrentThread.IsBackground}
//            IsThreadPoolThread:     {Thread.CurrentThread.IsThreadPoolThread}

//            """);
//    });
//0 → haradan başla
//students.Count → hara qədər get
//ParallelOptions → neçə thread işləsin, dayandırma imkanları və s.
//1. MaxDegreeOfParallelism
//Nə qədər thread eyni vaxtda işləyə biləcəyini müəyyən edir.
//Default: -1(sistem CPU nüvələrinin sayına görə maksimumu seçir).
//2. CancellationToken
//Paralel əməliyyatı vaxtından əvvəl dayandırmaq üçün istifadə olunur.
//Adətən CancellationTokenSource ilə birlikdə işlədilir.
//3. TaskScheduler
//İstifadə olunan Task scheduler-i dəyişməyə imkan verir.
//Default olaraq TaskScheduler.Default istifadə olunur → bu da .NET-in daxili ThreadPool-udur.
//Əgər sən xüsusi TaskScheduler yazmısansa, bunu burda verə bilərsən.
//Çox nadir hallarda dəyişdirilir (məsələn, UI kontekstində xüsusi scheduler lazım olanda).

//i => { ... } → hər tələbə üçün icra olunacaq iş

//Stopwatch stopwatch = new();
//stopwatch.Start();

//for (int i = 0; i < students.Count; i++)
//{
//    students[i].Group = "FSDM_Oct_24_4_az";
//    Thread.Sleep(1);
//}
//Console.WriteLine("Students group add for finished");
//var syncFor = stopwatch.ElapsedTicks;
//stopwatch.Restart();
//stopwatch.Start();
//Parallel.For(0, students.Count,
//    i =>
//    {
//        students[i].Group = "FSDM_Oct_24_5_az";
//        Thread.Sleep(1);
//    });
//Console.WriteLine("Students group add parallel for finished");
//var parallelFor = stopwatch.ElapsedTicks;
//stopwatch.Stop();

//Console.WriteLine($"Synchrony for ->    {syncFor}"); // Standart For
//Console.WriteLine($"Parallel  for ->    {parallelFor}"); // Parallel For
//students.ForEach(Console.WriteLine);
//Console.ReadLine();

#endregion

#region PLINQ
/*
Adi LINQ sorğularını paralel (çox thread ilə) icra etməyə imkan verir.
Məqsəd → çoxnüvəli CPU-dan faydalanmaq və böyük verilənlər üzərində sorğuları sürətləndirmək.
Paralleldən üstünlüyü də ordadır ki PLINQ bloklama işini özü daxilində həll edir yəni Critical Section problemi yaranmır.
Amma burada da biz kiçik içləri standart for istifadə olunmalıdır amma digər böyük işlərdə PLINQ və ya məsuliyyət bizdə olma şərti ilə Parallel istifadə oluna bilər.
İstifadəsi çox sadədir (sadəcə AsParallel() əlavə et).
*/

//Stopwatch stopwatch = new();
//stopwatch.Start();

//// Parallel.Foreach()
//int parallelCount = 0;
//object obj = new();
//Parallel.ForEach(students,
//    s =>
//    {
//        if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
//        {

//        }
//        //lock (obj)
//        //{
//        //    if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
//        //    {
//        //        parallelCount++;
//        //    }
//        //}

//    });
//var parallelForEach = stopwatch.ElapsedTicks;

//stopwatch.Restart();


//// LINQ
//int linqCount = students.Count(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"));

//var linqTicks = stopwatch.ElapsedTicks;

//stopwatch.Restart();


//// PLINQ

//var plinqCount = students.AsParallel().Count(s => s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"));
//var plinqTicks = stopwatch.ElapsedTicks;
//stopwatch.Stop();


//Console.WriteLine($"LINQ ->                 {linqTicks}         Count = {linqCount}");
//Console.WriteLine($"Parallel  foreach ->    {parallelForEach}       Count = {parallelCount}");
//Console.WriteLine($"PLINQ ->                {plinqTicks}        Count = {plinqCount}");
////students.ForEach(Console.WriteLine);
//Console.ReadLine();




#endregion

#region LINQ vs PLINQ vs Parallel
/*
Burada da gördüyümüz kimi burada Concurrent Collections istifadəsi daha düzgündür ki buda bizə ThreadSafe təmin edir və işimizin tam işləməsini və performans üstünlüyü verir. 
 
*/



Stopwatch stopwatch = new();
stopwatch.Start();
ConcurrentBag<string> namesParallel = [];
object obj = new();
Parallel.ForEach(students, s =>
{
    if (s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com"))
    {
        namesParallel.Add($"{s.FirstName} {s.LastName}");
        Thread.Sleep(1);

    }
});

var parallelTicks = stopwatch.ElapsedTicks;
stopwatch.Restart();

List<string> namesLinq = students
    .Where(s =>
    {
        Thread.Sleep(1);
        return s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com");
    })
    .Select(s => $"{s.FirstName} {s.LastName}")
    .ToList();

var linqTicks = stopwatch.ElapsedTicks;
stopwatch.Restart();

List<string> namesPLinq = students
    .AsParallel()
    .Where(s =>
    {
        Thread.Sleep(1);
        return s.FirstName.Length + s.LastName.Length > 15 && s.Email.ToLower().EndsWith("@gmail.com");
    })
    .Select(s => $"{s.FirstName} {s.LastName}")
    .ToList();

var plinqTicks = stopwatch.ElapsedTicks;
stopwatch.Restart();

stopwatch.Stop();

Console.WriteLine($"LINQ: {linqTicks}");
Console.WriteLine($"Parallel: {parallelTicks}");
Console.WriteLine($"PLINQ: {plinqTicks}");

Console.WriteLine();

Console.WriteLine($"LINQ count: {namesLinq.Count}");
Console.WriteLine($"Parallel count: {namesParallel.Count}");
Console.WriteLine($"PLINQ count: {namesPLinq.Count}");

#endregion















class Student
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Group { get; set; }
    public double Mark { get; set; }
    public override string ToString()
    {
        return $"""
            Id:             {Id}
            FirstName:      {FirstName}
            LastName:       {LastName}
            Age:            {Age}
            Email:          {Email}
            Group:          {Group}
            Mark:           {Mark}

            """;
    }
}
/*




































































































 
 
 
 
 
 




























































































































































































































































































 */