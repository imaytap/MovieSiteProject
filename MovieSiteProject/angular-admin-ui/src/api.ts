export let apiUrl = 'https://localhost:5001/api/'; // project api url
export let baseUrl = 'https://localhost:5001/'; // project url
export let baseUrlForImage = 'https://localhost:5001'; // project url without /
export let clientName = 'Angular-Web';
export var translates: any = {};

export function setApiUrl(url: string) {
  apiUrl = url;
}

export function setBaseUrl(url: string) {
  baseUrl = url;
}

export function setBaseUrlForImage(url: string) {
  baseUrlForImage = url;
}

export function setClientName(clientName: string) {
  clientName = clientName;
}
