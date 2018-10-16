# WerewolfAPI.Api.ActionApi

All URIs are relative to *https://project-ile.net:1038/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ActionGet**](ActionApi.md#actionget) | **GET** /action | Get list of actions
[**FindActionsByRoleId**](ActionApi.md#findactionsbyroleid) | **GET** /action/findByRole/{roleId} | Finds actions by roleId
[**GetActionById**](ActionApi.md#getactionbyid) | **GET** /action/{actionID} | Find action by ID


<a name="actionget"></a>
# **ActionGet**
> List<Action> ActionGet ()

Get list of actions

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class ActionGetExample
    {
        public void main()
        {
            var apiInstance = new ActionApi();

            try
            {
                // Get list of actions
                List&lt;Action&gt; result = apiInstance.ActionGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActionApi.ActionGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Action>**](Action.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findactionsbyroleid"></a>
# **FindActionsByRoleId**
> List<Action> FindActionsByRoleId (long? roleId)

Finds actions by roleId

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class FindActionsByRoleIdExample
    {
        public void main()
        {
            var apiInstance = new ActionApi();
            var roleId = 789;  // long? | Role Id to find actions

            try
            {
                // Finds actions by roleId
                List&lt;Action&gt; result = apiInstance.FindActionsByRoleId(roleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActionApi.FindActionsByRoleId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleId** | **long?**| Role Id to find actions | 

### Return type

[**List<Action>**](Action.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getactionbyid"></a>
# **GetActionById**
> Action GetActionById (long? actionID)

Find action by ID

Returns a single action

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GetActionByIdExample
    {
        public void main()
        {
            var apiInstance = new ActionApi();
            var actionID = 789;  // long? | ID of action to return

            try
            {
                // Find action by ID
                Action result = apiInstance.GetActionById(actionID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ActionApi.GetActionById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **actionID** | **long?**| ID of action to return | 

### Return type

[**Action**](Action.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

