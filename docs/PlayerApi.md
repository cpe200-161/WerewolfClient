# WerewolfAPI.Api.PlayerApi

All URIs are relative to *https://project-ile.net:1038/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**AddPlayer**](PlayerApi.md#addplayer) | **POST** /player | Add a new player to the system
[**DeletePlayer**](PlayerApi.md#deleteplayer) | **DELETE** /player/{playerId} | Deletes a player
[**FindPlayersByGame**](PlayerApi.md#findplayersbygame) | **GET** /player/findByGame/{gameID} | Finds Players by game
[**GetPlayerById**](PlayerApi.md#getplayerbyid) | **GET** /player/{playerId} | Find player by ID
[**LoginPlayer**](PlayerApi.md#loginplayer) | **POST** /player/login | Login into a player account
[**LogoutPlayer**](PlayerApi.md#logoutplayer) | **GET** /player/logout/{sessionID} | Player logout
[**PlayerGet**](PlayerApi.md#playerget) | **GET** /player | Get list of players
[**UpdatePlayer**](PlayerApi.md#updateplayer) | **PUT** /player | Update an existing player


<a name="addplayer"></a>
# **AddPlayer**
> Player AddPlayer (Player body)

Add a new player to the system

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class AddPlayerExample
    {
        public void main()
        {
            var apiInstance = new PlayerApi();
            var body = new Player(); // Player | Player object that needs to be added to the system

            try
            {
                // Add a new player to the system
                Player result = apiInstance.AddPlayer(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.AddPlayer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**Player**](Player.md)| Player object that needs to be added to the system | 

### Return type

[**Player**](Player.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="deleteplayer"></a>
# **DeletePlayer**
> void DeletePlayer (long? playerId)

Deletes a player

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class DeletePlayerExample
    {
        public void main()
        {
            var apiInstance = new PlayerApi();
            var playerId = 789;  // long? | Player id to delete

            try
            {
                // Deletes a player
                apiInstance.DeletePlayer(playerId);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.DeletePlayer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **playerId** | **long?**| Player id to delete | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="findplayersbygame"></a>
# **FindPlayersByGame**
> List<Player> FindPlayersByGame (string gameID)

Finds Players by game

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class FindPlayersByGameExample
    {
        public void main()
        {
            var apiInstance = new PlayerApi();
            var gameID = gameID_example;  // string | Game id

            try
            {
                // Finds Players by game
                List&lt;Player&gt; result = apiInstance.FindPlayersByGame(gameID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.FindPlayersByGame: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gameID** | **string**| Game id | 

### Return type

[**List<Player>**](Player.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="getplayerbyid"></a>
# **GetPlayerById**
> Player GetPlayerById (long? playerId)

Find player by ID

Returns a single player

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class GetPlayerByIdExample
    {
        public void main()
        {
            var apiInstance = new PlayerApi();
            var playerId = 789;  // long? | ID of player to return

            try
            {
                // Find player by ID
                Player result = apiInstance.GetPlayerById(playerId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.GetPlayerById: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **playerId** | **long?**| ID of player to return | 

### Return type

[**Player**](Player.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="loginplayer"></a>
# **LoginPlayer**
> Player LoginPlayer (Player body)

Login into a player account

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class LoginPlayerExample
    {
        public void main()
        {
            var apiInstance = new PlayerApi();
            var body = new Player(); // Player | Player object that at least contains login/password

            try
            {
                // Login into a player account
                Player result = apiInstance.LoginPlayer(body);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.LoginPlayer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**Player**](Player.md)| Player object that at least contains login/password | 

### Return type

[**Player**](Player.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="logoutplayer"></a>
# **LogoutPlayer**
> List<Player> LogoutPlayer (string sessionID)

Player logout

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class LogoutPlayerExample
    {
        public void main()
        {
            var apiInstance = new PlayerApi();
            var sessionID = sessionID_example;  // string | ID of player's session to logout

            try
            {
                // Player logout
                List&lt;Player&gt; result = apiInstance.LogoutPlayer(sessionID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.LogoutPlayer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **sessionID** | **string**| ID of player&#39;s session to logout | 

### Return type

[**List<Player>**](Player.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="playerget"></a>
# **PlayerGet**
> List<Player> PlayerGet ()

Get list of players

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class PlayerGetExample
    {
        public void main()
        {
            var apiInstance = new PlayerApi();

            try
            {
                // Get list of players
                List&lt;Player&gt; result = apiInstance.PlayerGet();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.PlayerGet: " + e.Message );
            }
        }
    }
}
```

### Parameters
This endpoint does not need any parameter.

### Return type

[**List<Player>**](Player.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="updateplayer"></a>
# **UpdatePlayer**
> void UpdatePlayer (Player body)

Update an existing player

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class UpdatePlayerExample
    {
        public void main()
        {
            var apiInstance = new PlayerApi();
            var body = new Player(); // Player | Player object that needs to be added to the system

            try
            {
                // Update an existing player
                apiInstance.UpdatePlayer(body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling PlayerApi.UpdatePlayer: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **body** | [**Player**](Player.md)| Player object that needs to be added to the system | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

