import { TP2CityPoiPage } from './app.po';

describe('tp2-city-poi App', () => {
  let page: TP2CityPoiPage;

  beforeEach(() => {
    page = new TP2CityPoiPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
