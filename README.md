```tex
Unity version: 2020.3.14f1
```



# Introduce

本Design Pattern範例是基於作者在看完"大話設計模式"以及"Head First Design Pattern"後的個人見解，因為沒有大量的項目經驗，所以會有知識點的疏漏以及錯誤。



# References

- 點開[UML圖](https://drive.google.com/file/d/1CqL6Sq6a-bgfTyaOKfM-8fHHSPiz7__c/view?usp=sharing)後，點擊上方的`使用「diagrams.net」開啟`，就可以查看各模式例子的UML圖。



# 原則 (Principles)

- **SRP (Single Responsibility Principle, 單一責任原則) :** 一個類應該只有一個改變的理由。
- **DIP (Dependency Inversion Principle, 依賴倒轉原則) :**  不要依賴實現，要依賴接口。
  - **(Hollywood Principle, 好萊塢原則) :** **上層模塊**儘量不要輪詢**下層模塊**。而是使用通知的形式。
- **OCP (Open-Closed Principle, 開放關閉原則) :**  對擴展開放，對修改關閉。
- **CARP (Composition/Aggregate Reuse Principle, 合成/聚合複用原則):** 少用繼承，多用組合。
- **LKP/LOD (Least Knowledge Principle/Law of Demeter, 最少知識原則/迪米特原則) :** 只和自己直接有關系的"朋友"交談。
- **ISP (Interface Segregation Principle, 接口隔離原則) :** 要求儘量將臃腫龐大的接口拆分成更小的和更具體的接口，讓接口中只包含客戶感興趣的方法。
- **LSP (Liskov Substitution Principle, 里氏替換原則) :** 定義了繼承的原則。通俗來講，子類可以擴展父類的功能，但不能改變父類原有的功能。
  1. 子類可以實現父類的抽象方法，但不能覆蓋父類的非抽象方法。
  2. 子類可以擴展自己的方法。
  3. 子類的前置條件不能被加強: 參數不能超過父類的可控範圍
  4. 子類的後置條件不能被削弱: 輸出範圍不能小於父類的輸出



# 設計模式 (Design Patterns)

## 工廠模式 (Factory)

> 簡單工廠 (Simple Factory) : 有時候不被算作一種模式。將對象創建封裝，供多個用戶使用。
>
> 工廠方法 (Factory Method) : 提供一個接口，用於創建相關或依賴對象的家族，而不需要明確指定具體類。
>
> 抽象工廠 (Abstract Factory) : 定義了一個建對象的接口，但由子類來決定要實列化的類是哪一個。工廠方法只讓類把實例化推遲到子類。

**簡單工廠**就是簡單的`switch`方式來選擇要創建的對象。在C#或Java中可以利用Reflection機制將`switch`去掉，實現更靈活的工廠。

**工廠方法**就是將**簡單工廠**變成類的形式，具體的創建對象算法交由子類實現，而基類或inteface只提供接口供用戶使用。

**抽象工廠**就是**工廠方法**的集合。



## 單例模式 (Singleton)

> 確保一個類只有一個實例，並提供一個全局訪問點。

### 單例類 vs. 靜態類

單例類實實在在的是一個"實例"，可以作為參數傳遞。"實例"是在OOP中操作的重要的對象之一，它遵守OOP思想。也就是說，單例類可以「繼承」，有「多態」的特性，能夠「封裝」起來。



### 單例類的創建方式

- 直接在變量中初始化

- 延遲加載 (Lazy Loading)

- 加鎖解決延遲加載的多線程的重覆創建問題
  - 單鎖
  - 多重檢測鎖 (double checked locking)

- 靜態內部類
- .NET Framework 4+中的Lazy<T>，可以實現延遲加載，並且解決多線程的重覆創建問題



## 策略模式 (Strategy)

> 定義了算法族，分別封裝起來，使它們之間可以相互替換，此模式使算法的變化獨立於使用算法的用戶。

通過**聚合**的形式，將會變化的「算法」分別封裝，成為新的算法蔟。這樣的好處是將變化從用戶中分離，達到算法的變化獨立於用戶的效果。並且同一個算法蔟之間，算法可以相互替換。



## 裝飾者模式 (Decorate)



## 觀察者模式 (Observer)



### 事件與委託 (event & delegate)



## 模板模式 (Template)

> 在一個方式中定義一個算法的骨架，而將一些步驟延遲到了子類中。模板方式使得子類可以在不改變算法結構的情況下，重新定義算法中的某些步驟。

是OOP中的繼承的其中一種用法。將一套算法中的具體實現延遲到子類中，這樣做的好處是可以使一套算法可以有多種不同的版本。



## 外觀模式 (Facade)

> 提供了一個統一的接口，用來訪問子系統中的一群接口。外觀定義了一個高層接口，讓子系統更容易使用。

簡單地來說，可以為一些常用的功能創建一個接口(例如: 游戲開始時會創建關卡、播放音樂、啟動各種的判斷器等)。這樣一來，用戶就不需要與多種類交互，達到解耦的目的。

但是，外觀類中的接口，有時候會變得異常龐大，使得維護難度提升。因此，這種模式應該只用於"常用"的功能中，而非一些只在一個地方使用的功能。



## 適配器模式 (Adapter)

> 將一個類的接口，轉換成客戶的期望的另一個接口。適配器讓原本接口不兼容的類可以合作無間。

相當於多了一個中間件，這一個中間件以"適配器"的身份，負責做兩邊的通信員。與**代理模式**類似。



## 命令模式 (Command)

> 將”請求”封裝成對象，以便使用不同的請求，隊列或者日志來參數化變化對象。命令模式支持可撤銷的操作。

與**策略模式**很像，但是策略模式封裝的是"行為"，而命令模式封裝的是"請求"。兩者有概念上的差別。且一般來說，命令都是以「隊列」的形式出現的，並且"請求"是能被撤銷的。



## 代理模式 (Proxy)

> 為另一個對象提供一個替身或占位符以控制對這個對象的認知。

與**適配器模式**一樣，也是作為一個中間件運作，但是他並不是只負責單一的對象，而是負責多個對象的中間件。能夠自由地切換到任意能代理的對象，令「使用者」與「具體對象」之間解除耦合。



## 橋接模式 (Bridge)

> 將抽象部分與它的實現部分分離，使它們都可以獨立地變化。

與**策略模式**很像，可以簡單地理解為"大"的策略模式。**策略模式**中，只考慮單個類中的變化，將其抽象成新的算法家族。而在**橋接模式**中，考慮的是多個類對應的多個變化。



## 迭代器模式 (Iterator)

> 提供一種方法順序訪問一個聚合對象中的各個元素，而不暴露其內部的表示。

迭代器可以遍歷訪問容器中的物件，即能對一個**數組(Aggregate)**進行遍歷。

迭代器的屬性一般有:

1. First () : 獲得首元素
2. Next () : 移動到下一個元素
3. IsDone () : 是否已經到達最後的元素

4. Current () : 取得當前的元素

在C#中，提供了`IEnumerator`和`IEnumerable`實現**迭代器模式**。且在C#2.0以上的版本中，在`IEnumerable`加入了`yield return`關鍵字，可以由編譯器自動創建`IEnumerator`的實現，無需手動創建。



## 組合模式 (Composite)

> 允許你將對象組合成樹形結構來表現”整體/部分”層次結構。組合能讓客戶以一致的方式處理個別對象以及對象組合。

在**組合模式**中的最重要的點就是, Leaf與Composite的操作是一致的。在使用者看來，操作一個Leaf和操作一個Composite是沒有分別的。但是在Composite的內部實現中，實際上會調用他的所有**子節點**的方法。

此外，**組合模式**經常與**迭代器模式**一起使用。利用**迭代器**遍歷樹形結構。

### 安全方法 vs 透明方法

在組合模式中的節點繼承基類方法有兩種形式，一種稱為**安全方法**，另一種稱為**透明方法**。

如果基類有add和remove方法的話，那麼在Leaf中也會持有這兩個方法，但實際上Leaf的add和remove都是沒有用的，這是為了使用者的使用一致性，而不需要判斷節點是Leaf還是Composite。這種繼承方式稱為**透明方法**。**安全方法**則是相反。



## 中介者/調停者模式 (Mediator)

> 用一個中介對象來封裝一系列的對象交互。中介者使各對象不需要顯示地相互引用，從而使其耦合松散，而且可以獨立地改變他們之間的交互。

當對象與對象之間的關係很複雜時，就可以通過中介者，將這些關係封裝到一個新的類中管理，這樣一來，各對象之間的耦合便能得到消除，而只需要關心新的中介者類中。

但是與**外觀模式**一樣，需要注意不能使中介者類變得過於龐大。



## 原型模式 (Prototype)

> 用原型實例指定創建對象的種類，並且通過拷貝這些原型創建新的對象。

簡單地來說，就是對象的Clone。因為`clone`()不會調用`constructor`，所以當類的`constructor`異常複雜時，使用`clone()`會比`new()`更快。

Clone類型:

1. Deep Clone
2. Shallow Clone



## 備忘錄模式 (Memento)

> 在不破壞封裝性的前提下，捕獲一個對象的內部狀態，並在該對象之外保存這狀態。這樣以後就可將該對象恢復到原先保存的狀態。

相當於對象的備份，可以恢復到上一個狀態。經常使用的Photoshop裏的撤銷功能，時空幻境中時光倒流功能等等，都可以利用**備忘錄模式**。

為了遵守**單一責任原則**，將功能從對象中分離出來。



## 訪問者模式 (Visitor)

> 表示一個作用於某對象結構中的各元素的操作。它使你可以在不改變各元素的類的前提下定義作用於這些元素的新操作。



## 其它

### Mediator vs Facade vs Proxy

**Facade:** 系統的接口的集合，這些系統之間沒有任何關聯。例如「打開電視」與「打開音響」兩個動作之間是完全沒有關係的。實際上系統與系統之間並沒有耦合。

**Mediator:** 是將系統與系統之間的"關聯"封裝起來，使系統與系統之間的耦合降低。此外，當發生改變時，用戶也只需要關心Mediator類。

**Proxy:** 代理與實際的類是同源的，具有相同的成員變量和方法。實際類能做的，代理類也能做。是降低用戶與系統之間的耦合的模式。
