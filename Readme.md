<!-- default file list -->
*Files to look at*:

* [Customer.cs](./CS/ConsoleApplication1/Customer.cs) (VB: [Customer.vb](./VB/ConsoleApplication1/Customer.vb))
* [Program.cs](./CS/ConsoleApplication1/Program.cs) (VB: [Program.vb](./VB/ConsoleApplication1/Program.vb))
* **[Service1.svc.cs](./CS/WcfService1/Service1.svc.cs) (VB: [Service1.svc.vb](./VB/WcfService1/Service1.svc.vb))**
* [Web.config](./CS/WcfService1/Web.config) (VB: [Web.config](./VB/WcfService1/Web.config))
* [Service1.svc.cs](./CS/WcfService2/Service1.svc.cs) (VB: [Service1.svc.vb](./VB/WcfService2/Service1.svc.vb))
* [Web.config](./CS/WcfService2/Web.config) (VB: [Web.config](./VB/WcfService2/Web.config))
<!-- default file list end -->
# How to create a data caching service that helps improve performance in distributed applications


<p><strong>Scenario:<br /> </strong>In the <a href="https://www.devexpress.com/Support/Center/p/E4930">How to connect to a remote data service instead of using a direct database connection</a> example we described how to connect to the <strong>WCF service</strong> via console application. <br /> If you want to take advantages of <a href="https://documentation.devexpress.com/#XPO/CustomDocument9892"><u>XPO data caching</u></a> using this solution, the only difference is in using the <strong>ICachedDataStore</strong> interface and the <strong>CachedDataStoreService</strong> base service class that implements this interface.</p>
<p><strong>Steps to implement<br /> 1. </strong>Create a data service and console applications as described in the <a href="https://www.devexpress.com/Support/Center/p/E4930">How to connect to a remote data service instead of using a direct database connection</a> example.<u><br /> </u><strong>2. </strong>Modify the service class as shown in the <em>WCFService1\Service1 </em>code file: use the <a href="https://documentation.devexpress.com/#XPO/clsDevExpressXpoDBCachedDataStoreServicetopic"><u>CachedDataStoreService</u></a> as base class, create a connection provide and data store.<br /> <strong>3. </strong>Modify the <em>web.config</em>file as shown in the <em>WCFService1\web.config</em> file.</p>
<p>There is no need to modify the client part since the service name has not been changed, and in addition, the “data caching domain” of our service is automatically detected by XPO.<br /> It is easy to configure which tables should be cached and which ones shouldn't using the following code from the <em>Service1 </em>code file:</p>


```cs
 DataCacheRoot dataCacheRoot = new DataCacheRoot(dataStore)
 dataCacheRoot.Configure(new DataCacheConfiguration(DataCacheConfigurationCaching.InList, "Customer")
 MainDataStore = dataCacheRoot;
```




```vb
Dim dataCacheRoot As New DataCacheRoot(dataStore)
dataCacheRoot.Configure(New DataCacheConfiguration(DataCacheConfigurationCaching.InList, "Customer"))
MainDataStore = dataCacheRoot
```


<p>This approach is useful for tables, which are frequently changed.</p>
<p><strong>4.</strong> Create a data caching service based on the <a href="http://community.devexpress.com/blogs/xpo/archive/2007/05/16/xpo-beta-feature-sqldependency-support.aspx"><u>SqlDependency</u></a> feature of the MS SQL Server. This approach is demonstrated in the <em>WCFService2.Service1.xx </em>file.</p>
<p><strong>Important notes</strong></p>
<p>If you are using an XAF client, then in the simplest case, you can just set the <em>XafApplication.ConnectionString</em> to the address of your data store service (<a href="http://localhost:55777/Service1.svc">http://localhost:55777/Service1.svc</a>). Refer to the <a href="https://documentation.devexpress.com/#Xaf/CustomDocument3155"><u>Connect an XAF Application to a Database Provider</u></a> help article for more details.</p>
<p><strong>Troubleshooting</strong><br />1. If WCF throws the "<em>Entity is too large</em>" error, you can apply a standard solution from StackOverFlow: <a href="http://stackoverflow.com/questions/10122957/">http://stackoverflow.com/questions/10122957/</a><br />2. If WCF throws the "<em>The maximum string content length quota (8192) has been exceeded while reading XML data.</em>" error, you can extend bindings in the following manner:</p>


```xml
<bindings>
      <basicHttpBinding>
        <binding name="ServicesBinding" maxBufferPoolSize="2147483647" maxReceivedMessageSize="2147483647" maxBufferSize="2147483647" transferMode="Streamed" >
          <readerQuotas maxDepth="2147483647"
            maxArrayLength="2147483647"
            maxStringContentLength="2147483647"/>
        </binding>
      </basicHttpBinding>
</bindings>
```


<p>See <a href="http://stackoverflow.com/questions/6600057/the-maximum-string-content-length-quota-8192-has-been-exceeded-while-reading-x">The maximum string content length quota (8192) has been exceeded while reading XML data</a></p>
<p><strong>See also:</strong><br /> <a href="https://www.devexpress.com/Support/Center/p/E4930">How to connect to a remote data service instead of using a direct database connection</a><br /> <a href="https://www.devexpress.com/Support/Center/p/E5072">How to implement a distributed object layer service working via WCF</a><u><br /> </u><a href="https://www.devexpress.com/Support/Center/p/E4993">How to connect to a remote data service from a Silverlight application<br /></a></p>
<p><a href="https://www.devexpress.com/Support/Center/p/E5137">How to connect to remote data store and configure WCF end point programmatically</a></p>

<br/>


