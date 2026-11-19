param location string = resourceGroup().location
param appName string = 'ardbhrufola'
param planName string = 'ASP-Silo-bfa5'
param planSku string = 'F1'

resource plan 'Microsoft.Web/serverfarms@2025-03-01' = {

  name: planName
  location: location
  sku: {
    name: planSku
  } 
  kind: 'linux'
  properties: {
    reserved: true
  }
}

resource appInsights 'Microsoft.Insights/components@2020-02-02'  existing = {
  name: 'ardbhrufola'

}

resource webApp 'Microsoft.Web/sites@2025-03-01' =  {
  name: appName
  location: location 
  tags: {
    'hidden-link: /app-insights-resource-id': appInsights.id
  
  }
  properties: {
    serverFarmId: plan.id
    httpsOnly: true
    siteConfig: {linuxFxVersion: 'DOTNETCORE|10.0'}
  }
}
