# WebAPI-NET
## REPOSITORY PATTERN  
1.**Create interface**  
	- create filename : "I...Repository.cs"  
2.**Create Model (Create for validation easyly)**  
3.**Using "Automapper NetCore" for data transmission**   
	- init ->Helper->ApplicationMapper.cs  
	- kế thừa từ Profile  
4.**Đăng ký Automapper:** builder.Services.AddAutoMapper(typeof(Program));  
5.**Tao class để implement cho I...Repository**  
	- Helper -> ...Repository  
	- public ...Repository(..context, ...mapper)  
6.**Đăng ký Life cycle DI:**
	- AddSingleton(), AddTransient(), AddScoped()
	