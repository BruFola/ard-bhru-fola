import http from 'k6/http';
import { check, sleep } from 'k6';

const BASE_URL = __ENV.BASE_URL || 'https://ardbhrufola-staging-h8avesaehdgzh2ay.spaincentral-01.azurewebsites.net/' ;

export const options = {
vus: 10,
duration: '10s',

thresholds: {
    http_req_failed: ['rate<0.01'],
    http_req_duration: ['p(95)<500'],
}

};

export default function () {
  const response = http.get(BASE_URL);
  check(response, { 'status is 200': (r) => r.status === 200 });
  sleep(1);
}