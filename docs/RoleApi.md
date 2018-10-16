# WerewolfAPI.Api.RoleApi

All URIs are relative to *https://project-ile.net:1038/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**GetRoleById**](RoleApi.md#getrolebyid) | **GET** /role/{roleId} | Find role by ID
[**RoleGet**](RoleApi.md#roleget) | **GET** /role | Get list of roles


<a name="getrolebyid"></a>
# **GetRoleById**
> Role GetRoleById (long? roleId)

Find role by ID

Returns a single role

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GetRoleByIdExample
    {
        public void main()
        {
            var apiInstance = new RoleApi();
            var roleId = 789;  // long? | ID of role to return

            try
            {
                // Find role by ID
                Role result = apiInstance.GetRoleById(roleId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoleApi.GetRoleById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **roleId** | **long?**| ID of role to return | 

### Return type

[**Role**](Role.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="roleget"></a>
# **RoleGet**
> List<Role> RoleGet ()

Get list of roles

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class RoleGetExample
    {
        public void main()
        {
            var apiInstance = new RoleApi();

            try
            {
                // Get list of roles
                List&lt;Role&gt; result = apiInstance.RoleGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling RoleApi.RoleGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Role>**](Role.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

