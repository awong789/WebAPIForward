# WebAPIForward

Forward simple Get request to Xively API so you can monitor each data stream value. This web application to be hosted separately and act as a message forwarder to Xively API.
```
 [Device] --> [WebAPIForward] --> [Xively API] --> [Xively Dashboard]
``` 
 Xively connectivity can be specified in configuration file.

##Usage 
Example request: 
```
http://{domain}/api/values?longitude=152&latitude=162
```

This will generate request to Xively API:
```
PUT https://api.xively.com/v2/feeds/{id}
```

**Header :**
```
X-ApiKey : {value is predefined in web config}
```
**Body:**
```
{
  "version":"1.0.0",
   "datastreams" : [ {
    "id" : "longitude",
      "current_value" : "152"
    },
      "id" : "latitude",
      "current_value" : "162"
    }
  ]
}
``` 

##Configuration: Web.Config
```
    <add key="host" value="api.xively.com"/>
    <add key="requestRoute" value="/v2/feeds/{insert your api route here}"/>
    <add key="apiKey" value="{insert your apiKey here}"/> 
```
