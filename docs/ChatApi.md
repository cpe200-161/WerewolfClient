# WerewolfAPI.Api.ChatApi

All URIs are relative to *https://project-ile.net:1038/v1*

Method | HTTP request | Description
------------- | ------------- | -------------
[**ChatGameIDSessionIDChatIDGet**](ChatApi.md#chatgameidsessionidchatidget) | **GET** /chat/{gameID}/{sessionID}/{chatID} | Retrieve list of chat messages
[**ChatGameIDSessionIDPost**](ChatApi.md#chatgameidsessionidpost) | **POST** /chat/{gameID}/{sessionID} | Post a message to game


<a name="chatgameidsessionidchatidget"></a>
# **ChatGameIDSessionIDChatIDGet**
> List<ChatMessage> ChatGameIDSessionIDChatIDGet (int? gameID, string sessionID, int? chatID)

Retrieve list of chat messages

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class ChatGameIDSessionIDChatIDGetExample
    {
        public void main()
        {
            var apiInstance = new ChatApi();
            var gameID = 56;  // int? | ID of game to perform action
            var sessionID = sessionID_example;  // string | ID of player'session to perform chat
            var chatID = 56;  // int? | First chat message ID to retrieve

            try
            {
                // Retrieve list of chat messages
                List&lt;ChatMessage&gt; result = apiInstance.ChatGameIDSessionIDChatIDGet(gameID, sessionID, chatID);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChatApi.ChatGameIDSessionIDChatIDGet: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gameID** | **int?**| ID of game to perform action | 
 **sessionID** | **string**| ID of player&#39;session to perform chat | 
 **chatID** | **int?**| First chat message ID to retrieve | 

### Return type

[**List<ChatMessage>**](ChatMessage.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="chatgameidsessionidpost"></a>
# **ChatGameIDSessionIDPost**
> void ChatGameIDSessionIDPost (long? gameID, string sessionID, ChatMessage body)

Post a message to game

Post a message to game

### Example
```csharp
using System;
using System.Diagnostics;
using WerewolfAPI.Api;
using WerewolfAPI.Client;
using WerewolfAPI.Model;

namespace Example
{
    public class ChatGameIDSessionIDPostExample
    {
        public void main()
        {
            var apiInstance = new ChatApi();
            var gameID = 789;  // long? | ID of game to perform action
            var sessionID = sessionID_example;  // string | ID of player'session to perform chat
            var body = new ChatMessage(); // ChatMessage | Chat message object to post to the game

            try
            {
                // Post a message to game
                apiInstance.ChatGameIDSessionIDPost(gameID, sessionID, body);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ChatApi.ChatGameIDSessionIDPost: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **gameID** | **long?**| ID of game to perform action | 
 **sessionID** | **string**| ID of player&#39;session to perform chat | 
 **body** | [**ChatMessage**](ChatMessage.md)| Chat message object to post to the game | 

### Return type

void (empty response body)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

