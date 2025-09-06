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

 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 */