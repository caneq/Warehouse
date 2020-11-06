# **Система складского учета**

**Разработать приложение для автоматизированной системы складского учета**

Некая компания, имеющая большой товарный оборот на собственных складские площадях и ведущая вручную весь учет, озабочена автоматизацией процесса движения товара на складах.

В процессе товарного движения участвуют следующие сотрудники компании:

- Менеджер по закупкам

В его функции входит работа с поставщиками товаров – отслеживание информации о закончившемся и заканчивающихся товарах, заказ новых товаров у различных поставщиков, отслеживание информации о состоянии оформленного заказа

- Менеджер по работе заказчиками

Прием заказов от клиентов и ответы на запросы клиентов о состоянии заказов

- Кладовщик

оформление нового товара, отгрузка товаров заказчикам, формирование партии отгрузки для службы доставки

- Курьер (служба доставки)

доставка выполненного заказа

- Бухгалтер

Функции – отслеживание информации об оплатах сделанных заказов клиентами (только после полной оплаты клиентом заказа кладовщик должен получить указание об отгрузке), оплата сделанных заказов поставщикам, оформление расходных и приходных накладных.

Можно выделить 6 основных функций системы:

• **Учет заказов** Прием заказов от клиентов и ответы на запросы клиентов о состоянии заказов.

• **Ведение счетов** Направление счетов клиентам и отслеживание платежей. Прием счетов от поставщиков и отсле­живание платежей поставщикам.

• **Отгрузка со склада** Составление спецификаций на комплектацию товаров, отправляемых со склада клиентам.

• **Складской учет** Постановка прибывающих товаров на учет и сня-

тие товаров с учета при отправке заказов.

• **Закупки** Заказ товаров поставщикам и отслеживание поставок.

• **Получение** Принятие на склад товаров от поставщиков **.**

Возможные сценарии работы системы

- Клиент делает заказ на товары.
- Клиент желает узнать состояние дел по его заказу.
- Клиент звонит, чтобы добавить или убрать некоторые позиции из заказа.
- Кладовщик получает указание отгрузить клиенту необходимое количество
товара.
- Служба доставки получает со склада заказанные клиентом товары и готовит
их к отправке.
- Бухгалтерия готовит счет для клиента.
- Отдел закупок готовит заказ на новый товар.
- Отдел закупок добавляет или удаляет имя поставщика из списка.
- Отдел закупок запрашивает поставщика о состоянии заказа.
- Кладовщик заносит новый товар в список.

Каждый из основных сценариев может включать в себя ряд вторичных:

- Заказанного клиентом товара нет на складе.
- Заказ клиента неверно оформлен, или в нем присутствуют несуществующие
или устаревшие идентификаторы товаров.
- Клиент звонит, чтобы проверить состояние заказа, но не помнит точно что,
кем и когда было заказано.
- Кладовщик получил расходную накладную (документ по которому товар отгружается клиенту), но некоторые перечисленные в
ней товары не нашлись.
- Служба доставки получает заказанные клиентом товары, но они не соответ­ствуют заказу.
- …

Клиент и заказчик: код, наименование, страна, адрес, форма собственности, № банковского счета, наименование банка, ФИО руководителя, телефон, e-mail, ФИО менеджера (по закупкам/поставкам)

Товар:
<pre>
Промышленные товары
	бытовая техника
		телевизоры
			телевизор JVC LT-32FX38
			телевизор JVC LT-37FX77AT
			…
		холодильники
			холодильник Samsung RL28DBSW1
			холодильник Samsung  RS21KLAL2/XEK
			…
		……	
	канцелярские товары
		бумага
			Снегурочка A4/80, 500 листов
			Снегурочка A4/120, 500 листов
		……	
	оргтехника
	одежда
	обувь
	мебель
  
Продовольственные товары
	молочные
	мясные
	хлебобулочные
</pre>

Именованный товар может принадлежать только одному узлу, причем, конечному.

Товар: наименование, единица измерения (кг, литры, шт), описание, вес в кг, тара (упаковка), срок хранения в днях (может быть бессрочным), цена, страна происхождения

Заказ: № и дата заказа, заказчик, номенклатура заказа (список заказанных товаров с количеством и суммой по каждой позиции и итоговой суммой заказа, факт исполнения/неисполнения

Закупка: № и дата закупки, поставщик, номенклатура закупки (список товаров с количеством и суммой по каждой позиции и итоговой суммой закупки, факт исполнения/неисполнения

Склад: список всех наличных товаров со всеми свойствами, с указанием поставщика и даты поставки и ответственного за конкретный товар кладовщика. Выделять товары с истекшим сроком хранения. На складе работают несколько кладовщиков, каждый из которых отвечает за определенную группу товаров (например, за телевизоры).

Отчет: временной промежуток, дополнительные условия

Например:
- Список товаров, закупленных у указанного поставщика, за указанный промежуток времени, с промежуточными и общими итогами по количеству и сумме по каждому наименованию и в целом]
- Список товаров, поставленных указанному заказчику …
- Список товаров указанной страны происхождения …

Отчеты конвертировать в MS Excel или MSWord.

Некие базовые конструкции, читающие данные из информационных источников и записывающие данные.

В строке статуса приложения (Statusbar) выводить итоговую стоимость всех товаров на складе и текущую дату.
