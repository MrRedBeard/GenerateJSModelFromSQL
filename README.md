# GenerateJSModelFromEntitySQL
Generate SQL Data Model from Entity Model & SQL

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
