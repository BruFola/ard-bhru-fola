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

resource webApp 'Microsoft.Web/sites@2025-03-01' = {
  name: appName
  location: location 
  properties: {
    serverFarmId: plan.id
    httpsOnly: true
    siteConfig: {linuxFxVersion: 'DOTNETCORE|10.0'}
  }
}
