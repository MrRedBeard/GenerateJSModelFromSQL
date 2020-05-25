# GenerateJSModelFromEntitySQL
A simple console app that generates JavaScript Classes & Model Documentation that mirrors a Database Entity Model & SQL Database Structure.

I created this to simplify documentation writing and to keep js models in sync with the DB Model with less human error/laziness. 

#### From

## SQL Structure
### Widgets Table
```sql
	[WidgetID] [int] IDENTITY(1,1) NOT NULL,
	[WidgetContent] [varchar](max) NULL,
	[Color] [varchar](15) NULL,
	[Width] [float] NULL,
	[Height] [float] NULL,
	[Volume] [float] NULL,
	[CreatedDateTime] [datetime] NULL,
	[LastUpdatedDateTime] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[LastUpdatedBy] [int] NULL,
	[fk_UserID] [int] NULL
```

#### To

## Entity Object Class
```csharp
    public partial class Widget
    {
        public int WidgetID { get; set; }
        public string WidgetContent { get; set; }
        public string Color { get; set; }
        public Nullable<double> Width { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Volume { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<System.DateTime> LastUpdatedDateTime { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<int> LastUpdatedBy { get; set; }
        public Nullable<int> fk_UserID { get; set; }
    }
```

#### Then

## JavaScript Class
```
/**
* Do Not Edit
* Generate JS Model From Entity SQL Last Updated: 5/25/2020 11:42:28 AM
* This file was generated programmatically using GenerateJSModelFromEntitySQL via the Entity Model & Rule Sets
* Do Not Edit
*/
```
```javascript
  class clsWidget
  {
    constructor()
    {
      this.WidgetID = null;
      this.WidgetContent = '';
      this.Color = '';
      this.Width = null;
      this.Height = null;
      this.Volume = null;
      this.CreatedDateTime = null;
      this.LastUpdatedDateTime = null;
      this.CreatedBy = null;
      this.LastUpdatedBy = null;
      this.fk_UserID = null;
    }
  }
```

#### And

## DB Model Documentation
```
/**
* Do Not Edit
* Generate JS Model From Entity SQL Last Updated: 5/25/2020 11:42:28 AM
* This file was generated programmatically using GenerateJSModelFromEntitySQL via the Entity Model & Rule Sets
* Do Not Edit
*/
TableName|ColumnName|DataType|ColumnDescription
User|UserID|int|
User|FirstName|string|
User|LastName|string|
User|Email|string|
User|CreatedDateTime|datetime|
User|LastUpdatedDateTime|datetime|
User|CreatedBy|int|
User|LastUpdatedBy|int|
Widget|WidgetID|int|
Widget|WidgetContent|string|
Widget|Color|string|
Widget|Width|double|
Widget|Height|double|
Widget|Volume|double|
Widget|CreatedDateTime|datetime|
Widget|LastUpdatedDateTime|datetime|
Widget|CreatedBy|int|
Widget|LastUpdatedBy|int|
Widget|fk_UserID|int|
/**
* Do Not Edit
* Generate JS Model From Entity SQL Last Updated: 5/25/2020 11:42:28 AM
* This file was generated programmatically using GenerateJSModelFromEntitySQL via the Entity Model & Rule Sets
* Do Not Edit
*/
```

## Instructions
I included a sample database `SampleDB.sql`

Once Database is created create user `user` with password `user`

The app is preconfigured with a username of user and password user and connection path of localhost\SQLEXPRESS

The model name is set to `GenerateJSModelFromEntitySQL` this will need to be changed to match your model name if you choose to use this solution.

Run the solution to generate `DataModelInfo.txt` & `clsDataStructure.js`. These will be output in the same folder as the solution file. 

