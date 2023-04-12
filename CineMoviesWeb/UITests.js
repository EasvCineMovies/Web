import {Selector} from 'testcafe';

fixture('Getting Started').page('https://localhost:44337/')

test('Movie selection to seat', async t => {
    await t
        .click('#app > div > div > div.nav-scrollable > nav > div:nth-child(3) > a')
        .wait(5000)
        .takeScreenshot()
        .click('#app > div > main > article > table > tbody > tr > td:nth-child(6) > button')
        .takeScreenshot()
        .expect(Selector('#app > div > main > article > h3').innerText)
        .eql('Seats')
});

test('See reservations', async t => {
    await t
        .click('#app > div > div > div.nav-scrollable > nav > div:nth-child(2) > a')
        .takeScreenshot()
        .typeText('#app > div > main > article > div:nth-child(2) > input:nth-child(1)', 'bobthephone')
        .typeText('#app > div > main > article > div:nth-child(2) > input:nth-child(2)', 'bobthepassword')
        .click('#app > div > main > article > div:nth-child(2) > button')
        .takeScreenshot()
        .click('#app > div > div > div.nav-scrollable > nav > div:nth-child(4) > a')
        .takeScreenshot()
        .expect(Selector('#app > div > main > article > div > table > tbody > tr > td:nth-child(5) > button').innerText)
        .eql('Delete')
});